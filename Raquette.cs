using System.Numerics;
using Raylib_cs;

namespace Breakout;

static partial class Program
{
    /// <summary>Le rectangle occupé par la raquette à l'écran.</summary>
    static Rectangle RectangleRaquette()
    {
        return new Rectangle(positionRaquette.X, positionRaquette.Y, LARGEUR_RAQUETTE, HAUTEUR_RAQUETTE);
    }

    /// <summary>Déplace la raquette avec les flèches, sans sortir de la fenêtre.</summary>
    static void DeplacerRaquette(float dt)
    {
        
        if (Raylib.IsKeyDown(KeyboardKey.Left))
        {
            positionRaquette.X -= VITESSE_RAQUETTE * dt;
        }
        if (Raylib.IsKeyDown(KeyboardKey.Right))
        {
            positionRaquette.X += VITESSE_RAQUETTE * dt;
        }

        // Empeche de sortir a gauche de la fenetre
        if (positionRaquette.X < 0)
        {
            positionRaquette.X = 0;
        }
        
        
        // Empeche de sortir a gauche de la fenetre
        float largeurEcran = Raylib.GetScreenWidth();
        if (positionRaquette.X + LARGEUR_RAQUETTE > largeurEcran)
        {
            positionRaquette.X = largeurEcran - LARGEUR_RAQUETTE;
        }
    }

    /// <summary>Fait rebondir la balle si elle touche la raquette.</summary>
    static void RebondirSurRaquette()
    {
        if (positionBalle.Y + RAYON_BALLE >= positionRaquette.Y && positionBalle.Y - RAYON_BALLE <= positionRaquette.Y + HAUTEUR_RAQUETTE && positionBalle.X + RAYON_BALLE >= positionRaquette.X && positionBalle.X - RAYON_BALLE <= positionRaquette.X + LARGEUR_RAQUETTE)
        {

            positionBalle.Y = positionRaquette.Y - RAYON_BALLE;
            vitesseBalle.Y = -Math.Abs(vitesseBalle.Y);
        }
    }
}
