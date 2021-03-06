namespace Glass.Imaging.Recognition.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Media.Imaging;
    using Barcodes.MessagingToolkit;
    using Imaging;
    using Core;
    using DotImaging;
    using FullFx;
    using PostProcessing;
    using ZoneConfigurations;
    using LeadTools.Recognition;
    using Tesseract;

    public abstract class MultiEngineTestBase
    {
        private CompositeOpticalRecognizer opticalRecognizer;
        private readonly ILeadToolsLicenseApplier licenseApplier = new LeadToolsLicenseApplier();

        protected MultiEngineTestBase()
        {
            ImagingContext.BitmapOperations = new BitmapOperations();
        }

        protected CompositeOpticalRecognizer GetSut()
        {
            var ocrEngines = new List<IImageToTextConverter> { new TesseractOcrOcrService(), new LeadToolsZoneBasedOcrService(licenseApplier) };
            var barcodeEngines = new List<IImageToTextConverter> { new MessagingToolkitZoneBasedBarcodeReader(), new LeadToolsZoneBasedBarcodeReader(licenseApplier) };
            return opticalRecognizer ?? (opticalRecognizer = new CompositeOpticalRecognizer(ocrEngines.Concat(barcodeEngines)));
        }

        protected static IImage LoadImage(string s)
        {
            return s.LoadColor();
        }

        public string Extract(IImage bitmap, ITextualDataFilter filter, Symbology symbology)
        {
            var sut = GetSut();
            var recognizedPage = sut.Recognize(bitmap, RecognitionConfiguration.FromSingleImage(bitmap, filter, symbology));

            var uniqueZone = recognizedPage.RecognizedZones.First();
            return uniqueZone.RecognitionResult.Text;
        }
    }
}