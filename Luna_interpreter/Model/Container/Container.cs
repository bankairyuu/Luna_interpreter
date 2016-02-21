using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luna_interpreter.Model.Container
{
    /// <summary>
    /// Alibi osztály, mely az esetleges, paraméterekben megadott konstansokat tárolja
    /// </summary>
    public static class Container
    {
        /// <summary>
        /// A modul meghívásakor paraméterben megkapott folyamatpéldány értékének tárolására előre létrehozott statikus változó
        /// </summary>
        /// <remarks>
        /// Egy folyamatpéldány azonosítója csak pozitív egész szám lehet
        /// </remarks>
        public static int processInstance = -1;
    }
}
