namespace InOutLib
{
    public class CsvHelper : FileHelper
    {
        #region private attributs
        //TODO Private attributs - 2pts
        private string _path = "";
        private string _fileName = "";
        private char _seperator;
        #endregion private attributs

        #region constructor
        public CsvHelper(string path, string fileName, char separator = ';') : base(path, fileName)
        {
            //TODO Constructor - 3pts
            _path = path;
            _fileName = fileName;
            if (IsCharSupported(separator))
            {
                throw new UnsupportedSeparatorException();
            }
            _seperator = separator;
        }
        #endregion constructor

        #region public methods 
        public void ExtractFileContent()
        {
            //TODO ExtractFileContent - 6pts
            StreamReader streamReader = new StreamReader(_fullPath);
            string line;
            // Reads and stores lines from the file until eof.
            while ((line = streamReader.ReadLine()) != null)
            {
                this.Lines.Add(line);

            }
            streamReader.Close();

            if ( this.Lines.Contains(";;"))
            {
                
                throw new InOutLib.StructureException();
            }
            if(this.Lines.Contains(""))
            {
                throw new StructureException();
            } 
        }
        #endregion public methods

        #region private methods
        private bool IsCharSupported(char separator)
        {
            //TODO IsCharSupported - 2pts
            if (separator != ';')
            {
                return true;
            }
            return false;
        }
        #endregion privates methods

        #region nested classes
        public class CsvHelperException : FileHelperException{}
        public class UnsupportedSeparatorException : CsvHelperException { }
        public class StructureException : CsvHelperException { }
        #endregion nested classes
    }
}
