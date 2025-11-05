using System.Security.Cryptography;
using Spotify.Repository;
using Spotify.Model;
using System.Drawing;

namespace Spotify.Encryption;


class ImageHash
{
    public static void ComparaHash (Imatge Imatge)
    {
        

        Bitmap myImage = new Bitmap(10, 10); 
        int hash = myImage.GetHashCode(); 
    }
}