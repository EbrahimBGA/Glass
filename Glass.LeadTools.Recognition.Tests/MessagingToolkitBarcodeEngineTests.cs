﻿namespace Glass.Imaging.Recognition.Tests
{
    using Barcodes.MessagingToolkit;
    using Imaging;
    using Xunit.Abstractions;

    public class MessagingToolkitBarcodeEngineTests : BarcodeEngineTest
    {
        protected override IImageToTextConverter Engine { get; } = new MessagingToolkitZoneBasedBarcodeReader();

        public MessagingToolkitBarcodeEngineTests(ITestOutputHelper output) : base(output)
        {
        }

        protected override double AlphanumericSuccessRate => 0;
        protected override double NumericSuccessRate => 0.8;
    }
}