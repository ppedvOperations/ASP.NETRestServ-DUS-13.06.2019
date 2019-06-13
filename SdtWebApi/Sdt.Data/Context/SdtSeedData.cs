using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Sdt.Bo.Entities;

namespace Sdt.Data.Context
{
    //public class SdtSeedData : DropCreateDatabaseAlways<SdtDataContext>
    //public class SdtSeedData : DropCreateDatabaseIfModelChanges<SdtDataContext>
    public class SdtSeedData : CreateDatabaseIfNotExists<SdtDataContext>
    {
        protected override void Seed(SdtDataContext context)
        {
            InitializeAutoren(context);
            //base.Seed(context);
        }

        private void InitializeAutoren(SdtDataContext context)
        {
            //context.Database.ExecuteSqlCommand("TRUNCATE TABLE[Autoren]");

            //Save changes ist auch nicht nötig

            if (!context.Autoren.Any())
            {
                List<Autor> autors = new List<Autor>
                {
                    new Autor
                    {
                        Name = "Albert Einstein",
                        Beschreibung = "Physiker",
                        Geburtsdatum = new DateTime(1879, 03, 14),
                        Photo = GetFileBytes("einstein.jpg"),
                        PhotoMimeType = "image/jpeg",
                        Sprueche = new List<Spruch>
                        {
                            new Spruch
                            {
                                SpruchText =
                                    "Ich bin nicht sicher, mit welchen Waffen der dritte Weltkrieg ausgetragen wird, aber im vierten Weltkrieg werden sie mit Stöcken und Steinen kämpfen."
                            },
                            new Spruch
                            {
                                SpruchText = "Phantasie ist wichtiger als Wissen, denn Wissen ist begrenzt."
                            }
                        }
                    },
                    new Autor
                    {
                        Name = "Mark Twain",
                        Beschreibung = "Philosoph",
                        Geburtsdatum = new DateTime(1835, 11, 30),
                        Photo = GetFileBytes("twain.jpg"),
                        PhotoMimeType = "image/jpeg",
                        Sprueche = new List<Spruch>
                        {
                            new Spruch
                            {
                                SpruchText =
                                    "Gott hat den Menschen erschaffen, weil er vom Affen enttäuscht war. Danach hat er auf weitere Experimente verzichtet."
                            },
                            new Spruch
                            {
                                SpruchText = "Man könnte viele Beispiele für unsinnige Ausgaben nennen, aber keines ist treffender als die Errichtung einer Friedhofsmauer. Die, die drinnen sind, können sowieso nicht hinaus, und die, die draußen sind, wollen nicht hinein."
                            },
                            new Spruch
                            {
                                SpruchText = "Man vergisst vielleicht, wo man die Friedenspfeife vergraben hat. Aber man vergisst niemals, wo das Beil liegt."
                            }
                        }
                    },
                    new Autor
                    {
                        Name = "Oscar Wilde",
                        Beschreibung = "Schriftsteller",
                        Geburtsdatum = new DateTime(1854, 10, 16),
                        Photo = GetFileBytes("wilde.jpg"),
                        PhotoMimeType = "image/jpeg",
                        Sprueche = new List<Spruch>
                        {
                            new Spruch
                            {
                                SpruchText ="Gesegnet seien jene, die nichts zu sagen haben und den Mund halten."
                            },
                            new Spruch
                            {
                                SpruchText = "Ein Zyniker ist ein Mensch, der von jedem Ding den Preis und von keinem den Wert kennt."
                            },
                            new Spruch
                            {
                                SpruchText = "Die Ehe ist ein Versuch, zu zweit wenigstens halb so glücklich zu werden, wie man allein gewesen ist."
                            }
                        }
                    }
                };

                context.Autoren.AddRange(autors);
                context.SaveChanges();
            }

            //if (!Enumerable.Any(context.Autoren, c => c.Name == autor.Name))
            //    context.Autoren.Add(autor);
        }

        //This gets a byte array for a file at the path specified
        //The path is relative to the route of the web site
        //It is used to seed images
        private byte[] GetFileBytes(string image)
        {
            //var fileOnDisk = new FileStream($"{HttpRuntime.AppDomainAppPath}/Content/images/{image}", FileMode.Open);
            //byte[] fileBytes;
            //using (var br = new BinaryReader(fileOnDisk))
            //{
            //    fileBytes = br.ReadBytes((int)fileOnDisk.Length);
            //}
            //return fileBytes;

            //Alternative
            return File.ReadAllBytes($"{HttpRuntime.AppDomainAppPath}/Content/images/autoren/{image}");
        }
    }
}
