using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace m2sp {
    static class ImageLoader {
        public static readonly Dictionary<int, Image> elemPictures = LoadElements();
        public static readonly Dictionary<int, Image> magicksPictures = LoadMagicks();

        public static readonly Image correctSign = Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    m2sp.Properties.Resources.CorrectImg));
        public static readonly Image wrongSign = Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    m2sp.Properties.Resources.WrongImg));

        public static Image getBackground() {
            Stream stmImage = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    m2sp.Properties.Resources.BackgroundImg);
            return Image.FromStream(stmImage);
        }

        private static Dictionary<int, Image> LoadElements() {
            Dictionary <int, Image> pictures = new Dictionary<int, Image>();
            // Water
            Stream elemImage = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    m2sp.Properties.Resources.WaterImg);
            pictures.Add(Element.Water, Image.FromStream(elemImage));
            // Life
            elemImage = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    m2sp.Properties.Resources.LifeImg);
            pictures.Add(Element.Life, Image.FromStream(elemImage));
            // Shiled
            elemImage = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    m2sp.Properties.Resources.ShieldImg);
            pictures.Add(Element.Shield, Image.FromStream(elemImage));
            // Frost
            elemImage = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    m2sp.Properties.Resources.FrostImg);
            pictures.Add(Element.Frost, Image.FromStream(elemImage));
            // Lightning
            elemImage = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    m2sp.Properties.Resources.LightningImg);
            pictures.Add(Element.Lightning, Image.FromStream(elemImage));
            // Death
            elemImage = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    m2sp.Properties.Resources.DeathImg);
            pictures.Add(Element.Death, Image.FromStream(elemImage));
            // Earth
            elemImage = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    m2sp.Properties.Resources.EarthImg);
            pictures.Add(Element.Earth, Image.FromStream(elemImage));
            // Fire
            elemImage = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    m2sp.Properties.Resources.FireImg);
            pictures.Add(Element.Fire, Image.FromStream(elemImage));
            // Steam
            elemImage = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    m2sp.Properties.Resources.SteamImg);
            pictures.Add(Element.Steam, Image.FromStream(elemImage));
            // Ice
            elemImage = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    m2sp.Properties.Resources.IceImg);
            pictures.Add(Element.Ice, Image.FromStream(elemImage));
            // Poison
            elemImage = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    m2sp.Properties.Resources.PoisonImg);
            pictures.Add(Element.Poison, Image.FromStream(elemImage));

            return pictures;
        }

        private static Dictionary<int, Image> LoadMagicks() {
            Dictionary<int, Image> pictures = new Dictionary<int, Image>();
            // AbuseAScroll
            Stream elemImage = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    m2sp.Properties.Resources.SpellImg1);
            pictures.Add(Magick.AbuseAScroll, Image.FromStream(elemImage));
            // Concussion
            elemImage = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    m2sp.Properties.Resources.SpellImg2);
            pictures.Add(Magick.Concussion, Image.FromStream(elemImage));
            // Dispel
            elemImage = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    m2sp.Properties.Resources.SpellImg3);
            pictures.Add(Magick.Dispel, Image.FromStream(elemImage));
            // Disruptor
            elemImage = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    m2sp.Properties.Resources.SpellImg4);
            pictures.Add(Magick.Disruptor, Image.FromStream(elemImage));
            // DragonStrike
            elemImage = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    m2sp.Properties.Resources.SpellImg5);
            pictures.Add(Magick.DragonStrike, Image.FromStream(elemImage));
            // EmergencyTeleport
            elemImage = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    m2sp.Properties.Resources.SpellImg6);
            pictures.Add(Magick.EmergencyTeleport, Image.FromStream(elemImage));
            // FuriousFowl
            elemImage = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    m2sp.Properties.Resources.SpellImg7);
            pictures.Add(Magick.FuriousFowl, Image.FromStream(elemImage));
            // Guardian
            elemImage = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    m2sp.Properties.Resources.SpellImg8);
            pictures.Add(Magick.Guardian, Image.FromStream(elemImage));
            // Haste
            elemImage = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    m2sp.Properties.Resources.SpellImg9);
            pictures.Add(Magick.Haste, Image.FromStream(elemImage));
            // HigherlandBreeze
            elemImage = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    m2sp.Properties.Resources.SpellImg10);
            pictures.Add(Magick.HigherlandBreeze, Image.FromStream(elemImage));
            // IceTornado
            elemImage = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    m2sp.Properties.Resources.SpellImg11);
            pictures.Add(Magick.IceTornado, Image.FromStream(elemImage));
            // Push
            elemImage = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    m2sp.Properties.Resources.SpellImg12);
            pictures.Add(Magick.Push, Image.FromStream(elemImage));
            // Revive
            elemImage = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    m2sp.Properties.Resources.SpellImg13);
            pictures.Add(Magick.Revive, Image.FromStream(elemImage));
            // Sacrifice
            elemImage = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    m2sp.Properties.Resources.SpellImg14);
            pictures.Add(Magick.Sacrifice, Image.FromStream(elemImage));
            // SpikeQuake
            elemImage = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    m2sp.Properties.Resources.SpellImg15);
            pictures.Add(Magick.SpikeQuake, Image.FromStream(elemImage));
            // SummonLivingDeadPeople
            elemImage = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    m2sp.Properties.Resources.SpellImg16);
            pictures.Add(Magick.SummonLivingDeadPeople, Image.FromStream(elemImage));
            // Teleport
            elemImage = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    m2sp.Properties.Resources.SpellImg17);
            pictures.Add(Magick.Teleport, Image.FromStream(elemImage));
            // Thunderbolt
            elemImage = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    m2sp.Properties.Resources.SpellImg18);
            pictures.Add(Magick.Thunderbolt, Image.FromStream(elemImage));
            // Thunderhead
            elemImage = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    m2sp.Properties.Resources.SpellImg19);
            pictures.Add(Magick.Thunderhead, Image.FromStream(elemImage));

            return pictures;
        }
    }
}
