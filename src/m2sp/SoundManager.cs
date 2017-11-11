using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace m2sp {
    static class SoundManager {

        private const int MMSYSERR_NOERROR = 0;
        [DllImport("winmm.dll")]
        private static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);
        
        private static readonly SoundPlayer correctSound;
        private static readonly SoundPlayer wrongSound;

        static SoundManager() {
            uint volume = 0x3fff;
            ChangeVolume(volume);

            correctSound = new SoundPlayer(Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    m2sp.Properties.Resources.CorrectSound));
            wrongSound = new SoundPlayer(Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    m2sp.Properties.Resources.WrongSound));
        }

        public static void ChangeVolume(uint volume) {
            uint actualVolume = (uint)(((UInt16)volume & 0x0000ffff) | ((UInt16)volume << 16));
            waveOutSetVolume(IntPtr.Zero, actualVolume);
        }

        public static void PlayCorrectSound() {
            correctSound.Play();
        }

        public static void PlayWrongSound() {
            wrongSound.Play();
        }
    }
}
