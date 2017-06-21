// ---------------------------------------------------------
// Copyrights (c) 2014-2017 Seditio 🍂 All rights reserved.
// ---------------------------------------------------------

using System;
using System.Drawing;
using System.Threading;

using CUE.Net;
using CUE.Net.Brushes;
using CUE.Net.Devices.Generic.Enums;
using CUE.Net.Exceptions;
using CUE.Net.Gradients;
using CUE.Net.Groups;
using CUE.Net.Groups.Extensions;

namespace RGBifier
{
    public static class Program
    {
        public static void Main()
        {
            try
            {
                if(!CueSDK.IsSDKAvailable())
                {
                    Console.WriteLine("Ded");
                    Console.ReadKey(true);
                    Environment.Exit(0);
                }

                CueSDK.Initialize();
                Console.WriteLine("Initialized with x64-SDK");
                CueSDK.UpdateMode = UpdateMode.Continuous;
                var keyboard = CueSDK.KeyboardSDK;
                keyboard.Brush = (SolidColorBrush) Color.Black;
                var rainbowGradient = new RainbowGradient(0, 720);
                new RectangleLedGroup(keyboard, CorsairLedId.Q, CorsairLedId.D) {Brush = new LinearGradientBrush(rainbowGradient)}.Exclude(CorsairLedId.Q,
                    CorsairLedId.E);
                for(var i = 0; i < 100; i++)
                {
                    rainbowGradient.StartHue += 10f;
                    rainbowGradient.EndHue += 10f;
                    Thread.Sleep(100);
                }
            }
            catch(CUEException ex)
            {
                Console.WriteLine("CUE Exception! ErrorCode: " + Enum.GetName(typeof(CorsairError), ex.Error));
            }
            catch(WrapperException ex)
            {
                Console.WriteLine("Wrapper Exception! Message:" + ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception! Message:" + ex.Message);
            }
            while(true)
            {
                Thread.Sleep(1000);
            }
        }
    }
}