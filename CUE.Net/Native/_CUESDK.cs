// ReSharper disable UnusedMethodReturnValue.Global
// ReSharper disable UnusedMember.Global

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using CUE.Net.Devices.Generic.Enums;
using CUE.Net.Exceptions;

namespace CUE.Net.Native
{
    // ReSharper disable once InconsistentNaming
    internal static class _CUESDK
    {
        #region Libary Management

        private static IntPtr _dllHandle = IntPtr.Zero;

        /// <summary>
        /// Gets the loaded architecture (x64/x86).
        /// </summary>
        internal static string LoadedArchitecture { get; private set; }

        /// <summary>
        /// Reloads the SDK.
        /// </summary>
        internal static void Reload()
        {
            UnloadCUESDK();
            LoadCUESDK();
        }

        private static void LoadCUESDK()
        {
            if (_dllHandle != IntPtr.Zero) return;

            // HACK: Load library at runtime to support both, x86 and x64 with one managed dll
            List<string> possiblePathList = RuntimeInformation.OSArchitecture == Architecture.X64 ? CueSDK.PossibleX64NativePaths : CueSDK.PossibleX86NativePaths;
            string dllPath = null;
            foreach (string path in possiblePathList)
                if (File.Exists(path))
                {
                    dllPath = path;
                    break;
                }

            if (dllPath == null) throw new WrapperException($"Can't find the CUE-SDK at one of the expected locations:\r\n '{string.Join("\r\n", possiblePathList.Select(Path.GetFullPath))}'");

            _dllHandle = LoadLibrary(dllPath);

            _corsairSetLedsColorsPointer = Marshal.GetDelegateForFunctionPointer<CorsairSetLedsColorsPointer>(GetProcAddress(_dllHandle, "CorsairSetLedsColors"));
            _corsairGetDeviceCountPointer = Marshal.GetDelegateForFunctionPointer<CorsairGetDeviceCountPointer>(GetProcAddress(_dllHandle, "CorsairGetDeviceCount"));
            _corsairGetDeviceInfoPointer = Marshal.GetDelegateForFunctionPointer<CorsairGetDeviceInfoPointer>(GetProcAddress(_dllHandle, "CorsairGetDeviceInfo"));
            _corsairGetLedPositionsPointer = Marshal.GetDelegateForFunctionPointer<CorsairGetLedPositionsPointer>(GetProcAddress(_dllHandle, "CorsairGetLedPositions"));
            _corsairGetLedPositionsByDeviceIndexPointer = Marshal.GetDelegateForFunctionPointer<CorsairGetLedPositionsByDeviceIndexPointer>(GetProcAddress(_dllHandle, "CorsairGetLedPositionsByDeviceIndex"));
            _corsairGetLedIdForKeyNamePointer = Marshal.GetDelegateForFunctionPointer<CorsairGetLedIdForKeyNamePointer>(GetProcAddress(_dllHandle, "CorsairGetLedIdForKeyName"));
            _corsairRequestControlPointer = Marshal.GetDelegateForFunctionPointer<CorsairRequestControlPointer>(GetProcAddress(_dllHandle, "CorsairRequestControl"));
            _corsairReleaseControlPointer = Marshal.GetDelegateForFunctionPointer<CorsairReleaseControlPointer>(GetProcAddress(_dllHandle, "CorsairReleaseControl"));
            _corsairPerformProtocolHandshakePointer = Marshal.GetDelegateForFunctionPointer<CorsairPerformProtocolHandshakePointer>(GetProcAddress(_dllHandle, "CorsairPerformProtocolHandshake"));
            _corsairGetLastErrorPointer = Marshal.GetDelegateForFunctionPointer<CorsairGetLastErrorPointer>(GetProcAddress(_dllHandle, "CorsairGetLastError"));
        }

        private static void UnloadCUESDK()
        {
            if (_dllHandle == IntPtr.Zero) return;

            // ReSharper disable once EmptyEmbeddedStatement - DarthAffe 20.02.2016: We might need to reduce the internal reference counter more than once to set the library free
            while (FreeLibrary(_dllHandle)) ;
            _dllHandle = IntPtr.Zero;
        }

        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibrary(string dllToLoad);

        [DllImport("kernel32.dll")]
        private static extern bool FreeLibrary(IntPtr dllHandle);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetProcAddress(IntPtr dllHandle, string name);

        #endregion

        #region SDK-METHODS

        #region Pointers

        private static CorsairSetLedsColorsPointer _corsairSetLedsColorsPointer;
        private static CorsairGetDeviceCountPointer _corsairGetDeviceCountPointer;
        private static CorsairGetDeviceInfoPointer _corsairGetDeviceInfoPointer;
        private static CorsairGetLedPositionsPointer _corsairGetLedPositionsPointer;
        private static CorsairGetLedIdForKeyNamePointer _corsairGetLedIdForKeyNamePointer;
        private static CorsairGetLedPositionsByDeviceIndexPointer _corsairGetLedPositionsByDeviceIndexPointer;
        private static CorsairRequestControlPointer _corsairRequestControlPointer;
        private static CorsairReleaseControlPointer _corsairReleaseControlPointer;
        private static CorsairPerformProtocolHandshakePointer _corsairPerformProtocolHandshakePointer;
        private static CorsairGetLastErrorPointer _corsairGetLastErrorPointer;

        #endregion

        #region Delegates

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool CorsairSetLedsColorsPointer(int size, IntPtr ledsColors);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int CorsairGetDeviceCountPointer();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate IntPtr CorsairGetDeviceInfoPointer(int deviceIndex);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate IntPtr CorsairGetLedPositionsPointer();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate IntPtr CorsairGetLedPositionsByDeviceIndexPointer(int deviceIndex);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate CorsairLedId CorsairGetLedIdForKeyNamePointer(char keyName);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool CorsairRequestControlPointer(CorsairAccessMode accessMode);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool CorsairReleaseControlPointer(CorsairAccessMode accessMode);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate _CorsairProtocolDetails CorsairPerformProtocolHandshakePointer();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate CorsairError CorsairGetLastErrorPointer();

        #endregion

        // ReSharper disable EventExceptionNotDocumented

        /// <summary>
        /// CUE-SDK: set specified leds to some colors. The color is retained until changed by successive calls. This function does not take logical layout into account.
        /// </summary>
        internal static bool CorsairSetLedsColors(int size, IntPtr ledsColors) => _corsairSetLedsColorsPointer(size, ledsColors);

        /// <summary>
        /// CUE-SDK: returns number of connected Corsair devices that support lighting control.
        /// </summary>
        internal static int CorsairGetDeviceCount() => _corsairGetDeviceCountPointer();

        /// <summary>
        /// CUE-SDK: returns information about device at provided index.
        /// </summary>
        internal static IntPtr CorsairGetDeviceInfo(int deviceIndex) => _corsairGetDeviceInfoPointer(deviceIndex);

        /// <summary>
        /// CUE-SDK: provides list of keyboard LEDs with their physical positions.
        /// </summary>
        internal static IntPtr CorsairGetLedPositions() => _corsairGetLedPositionsPointer();

        /// <summary>
        /// CUE-SDK: provides list of keyboard or mousemat LEDs with their physical positions.
        /// </summary>
        internal static IntPtr CorsairGetLedPositionsByDeviceIndex(int deviceIndex) => _corsairGetLedPositionsByDeviceIndexPointer(deviceIndex);

        /// <summary>
        /// CUE-SDK: retrieves led id for key name taking logical layout into account.
        /// </summary>
        internal static CorsairLedId CorsairGetLedIdForKeyName(char keyName) => _corsairGetLedIdForKeyNamePointer(keyName);

        /// <summary>
        /// CUE-SDK: requestes control using specified access mode.
        /// By default client has shared control over lighting so there is no need to call CorsairRequestControl unless client requires exclusive control.
        /// </summary>
        internal static bool CorsairRequestControl(CorsairAccessMode accessMode) => _corsairRequestControlPointer(accessMode);

        /// <summary>
        /// CUE-SDK: releases previously requested control for specified access mode.
        /// </summary>
        internal static bool CorsairReleaseControl(CorsairAccessMode accessMode) => _corsairReleaseControlPointer(accessMode);

        /// <summary>
        /// CUE-SDK: checks file and protocol version of CUE to understand which of SDK functions can be used with this version of CUE.
        /// </summary>
        internal static _CorsairProtocolDetails CorsairPerformProtocolHandshake() => _corsairPerformProtocolHandshakePointer();

        /// <summary>
        /// CUE-SDK: returns last error that occured while using any of Corsair* functions.
        /// </summary>
        internal static CorsairError CorsairGetLastError() => _corsairGetLastErrorPointer();

        // ReSharper restore EventExceptionNotDocumented

        #endregion
    }
}
