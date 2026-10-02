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
        float vitesse = VITESSE_BALLE / MathF.Sqrt(2);

        vitesseBalle = new Vector2(vitesse, -vitesse);
    }

    /// <summary>Avance la balle selon sa vitesse.</summary>
    static void DeplacerBalle(float dt)
    {
        if (Raylib.IsKeyDown(KeyboardKey.Left))
        {
            positionBalle.X -= VITESSE_BALLE * dt;
        }
        if (Raylib.IsKeyDown(KeyboardKey.Right))
        {
            positionBalle.X += VITESSE_BALLE * dt;
        }

        // Empeche de sortir a gauche de la fenetre
        if (positionBalle.X < 0)
        {
            positionBalle.X = 0;
        }


        // Empeche de sortir a gauche de la fenetre
        float largeurEcran = Raylib.GetScreenWidth();
        if (positionBalle.X + RAYON_BALLE > largeurEcran)
        {
            positionBalle.X = largeurEcran - RAYON_BALLE;
        }

        positionBalle += vitesseBalle * dt;
    }

    /// <summary>Fait rebondir la balle sur les murs gauche, droit et haut.</summary>
    static void RebondirSurMurs()
    {
        // Rebond gauche
        if (positionBalle.X - RAYON_BALLE < 0)
        {
            positionBalle.X = RAYON_BALLE;
            vitesseBalle.X = -vitesseBalle.X;
        }

        // Rebond droit
        if (positionBalle.X + RAYON_BALLE > LARGEUR)
        {
            positionBalle.X = LARGEUR - RAYON_BALLE;
            vitesseBalle.X = -vitesseBalle.X;
        }

        // Rebond haut
        if (positionBalle.Y - RAYON_BALLE < 0)
        {
            positionBalle.Y = RAYON_BALLE;
            vitesseBalle.Y = -vitesseBalle.Y;
        }
    }

    /// <summary>Indique si la balle est entièrement sortie par le bas de la fenêtre.</summary>
    static bool BalleSortieEnBas()
    {
        return false;
    }
}
