using System.Security.Cryptography;
using Spotify.Repository;
using Spotify.Model;
using System.Drawing;
using System.Security.Cryptography;

namespace Spotify.Encryption;


class ImageHash
{
    public static void ComparaHash(Imatge imatge)
    {
        //He guardat el Hash de la imatge amb enterioritat a la bdd
        string HashBDD = imatge.Hash;

        Boolean hashCorreta = false;

        Bitmap myImage = new Bitmap(10, 10);
        int hashActual = myImage.GetHashCode();

        hashActual.ToString();


        using var HashImage = new Rfc2898DeriveBytes(imatge.Url, 10000);
        byte[] hash = HashImage.GetBytes(16);

        using var HashBDD16 = new Rfc2898DeriveBytes(HashBDD, 10000);
        byte[] hashBDD = HashImage.GetBytes(16);

        // aqui compararia que els dos hash estiguesin iguals un amb l'altre es a dir el que tinc a la imatge
        // i el que tenia guardat quant vaig pujar laimatge a la base de dades i despres retornaria True o false depen de sison iguals o no
        // if (HashBDD = hash )
        //  {
        //     hashCorreta = true;
        // };
    }
}