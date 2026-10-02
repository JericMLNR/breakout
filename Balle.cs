using Raylib_cs;
using System.Numerics;

namespace Breakout;

static partial class Program
{
    /// <summary>Pose la balle au milieu du dessus de la raquette.</summary>
    static void CollerBalleARaquette()
    {
        positionBalle.X = (LARGEUR - RAYON_BALLE) / 2.0f;
        positionBalle.Y = HAUTEUR - HAUTEUR_RAQUETTE - MARGE_BAS_RAQUETTE;
    }

    /// <summary>Donne à la balle sa vitesse de départ.</summary>
    static void LancerBalle()
    {
    }

    /// <summary>Avance la balle selon sa vitesse.</summary>
    static void DeplacerBalle(float dt)
    {
    }

    /// <summary>Fait rebondir la balle sur les murs gauche, droit et haut.</summary>
    static void RebondirSurMurs()
    {
    }

    /// <summary>Indique si la balle est entièrement sortie par le bas de la fenêtre.</summary>
    static bool BalleSortieEnBas()
    {
        return false;
    }
}
