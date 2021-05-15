using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace GestionnaireSerie
{
    public interface ISaveAndLoad
    {
        void SaveText(string filename, string text);
        string LoadText(string filename);
        void Delete(string filename);
    }
}
