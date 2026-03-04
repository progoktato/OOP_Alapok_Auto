using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppElsoOP
{
    public enum Tereptargy {sik, szikla, vizjeg, ritkaArany, ritkaAsvany};
    public class Cella
    {
        int sorIndex, oszlopIndex;
        char tartalom;
        Tereptargy targy;

        public Cella(int sorIndex, int oszlopIndex, Tereptargy targy)
        {
            this.sorIndex = sorIndex;
            this.oszlopIndex = oszlopIndex;
            this.targy = targy;
        }

        public Cella(int sorIndex, int oszlopIndex, char tartalom)
        {
            this.sorIndex = sorIndex;
            this.oszlopIndex = oszlopIndex;
            this.tartalom = tartalom;
        }

        //Color hatterszin;

        public int SorIndex { get => sorIndex; }
        public int OszlopIndex { get => oszlopIndex; }
        public char Tartalom { get => tartalom; set => tartalom = value; }
        internal Tereptargy Targy { get => targy; set => targy = value; }


    }
}
