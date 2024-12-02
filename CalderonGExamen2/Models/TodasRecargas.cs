using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalderonGExamen2.Models
{
    internal class TodasRecargas
    {
        public ObservableCollection<Recarga> Recargas { get; set; } = new ObservableCollection<Recarga>();
        public TodasRecargas() =>
           cargarRecarga();
        public void cargarRecarga()
        {
            Recargas.Clear();
            string appDataPath = FileSystem.AppDataDirectory;
            IEnumerable<Recarga> recargas = Directory
                                        .EnumerateFiles(appDataPath, "*.GabrielCalderon1.txt")

                                        .Select(filename => new Recarga()
                                        {
                                            Filename = filename,
                                            telefono = File.ReadAllText(filename),
                                            nombre = File.ReadAllText(filename),
                                            Date = File.GetLastWriteTime(filename)
                                        })
                                        .OrderBy(note => note.Date);
            foreach (Recarga recarga in recargas)
                Recargas.Add(recarga);
        }
    }
}
