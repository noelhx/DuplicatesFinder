namespace DuplicatesFinder
{
    public class ScannerFactory
    {
        public Scanner Create(ScanType scanType, ScanOptions scanOptions)
        {
            switch (scanType)
            {
                case ScanType.Simple:
                    return new SimpleScanner(scanOptions);

                case ScanType.Smart:
                    return new SmartScanner(scanOptions);

                default:
                    return null;
            }
        }
    }
}

