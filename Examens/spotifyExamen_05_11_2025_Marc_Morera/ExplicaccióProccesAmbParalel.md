Per guardar les Imatges amb paral·lel lo que feria primer es agafar el codi de guardar les imatges les guardarua en una colleccio de fitxers despres aniria crean tasques i aniria recorrguent la coleccio de fitxers i aniria fer un insert a cada fil amb cada fitxer una cosa sembla a aixo

   public async Task<List<Media>> ProcessAndInsertUploadedMediaRange(DatabaseConnection dbConn, Guid songId, IFormFileCollection files, String filePath)
         {
             var result = new List<Media>();
             List<Task> added = new List<Task>();

             for (int i = 0; files.Count; i++)
             {
                 added.Add(Task.Run(() => ProcessAndInsertUploadedMedia(dbConn, songId, files[i], filePath)));
                 if (added != null)
                     result.Add(added[i]);
             }
             Task.WaitAll(added.ToArray());
             return result;
         }