using System.Numerics;
using Raylib_cs;

namespace Breakout;

static partial class Program
{
    static void Main()
    {
        Raylib.InitWindow(LARGEUR, HAUTEUR, "Breakout");
        Raylib.SetTargetFPS(60);
        Reinitialiser();

        while (!Raylib.WindowShouldClose())
        {
            float dt = Raylib.GetFrameTime();

            switch (etat)
            {
                case EtatJeu.Attente:
                    MettreAJourAttente(dt);
                    break;
                case EtatJeu.Jeu:
                    MettreAJourJeu(dt);
                    break;
                case EtatJeu.Perdu:
                case EtatJeu.Gagne:
                    MettreAJourFin();
                    break;
            }

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);
            DessinerJeu();
            if (etat == EtatJeu.Perdu || etat == EtatJeu.Gagne)
            {
                DessinerFin();
            }
            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }

    /// <summary>Remet le jeu dans son état de départ.</summary>
    static void Reinitialiser()
    {
        positionRaquette.X = (LARGEUR - LARGEUR_RAQUETTE) / 2.0f;
        positionRaquette.Y = HAUTEUR - HAUTEUR_RAQUETTE - MARGE_BAS_RAQUETTE;
        CollerBalleARaquette();

    }

    /// <summary>Une image de jeu dans l'état Attente.</summary>
    static void MettreAJourAttente(float dt)
    {
        DeplacerRaquette(dt);
        DeplacerBalle(dt);

        if (Raylib.IsKeyPressed(KeyboardKey.Space))
        {
            LancerBalle();
            etat = EtatJeu.Jeu;
        }
    }

    /// <summary>Une image de jeu dans l'état Jeu.</summary>
    static void MettreAJourJeu(float dt)
    {
        DeplacerRaquette(dt);
        DeplacerBalle(dt);
        RebondirSurMurs();
        RebondirSurRaquette();
    }

    /// <summary>Une image de jeu dans les états Perdu et Gagne.</summary>
    static void MettreAJourFin()
    {
    }


}
