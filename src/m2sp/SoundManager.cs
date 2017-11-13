using System.Media;
using System.Reflection;

namespace m2sp {
    static class SoundManager {        
        private static readonly SoundPlayer correctSound;
        private static readonly SoundPlayer wrongSound;

        static SoundManager() {
            correctSound = new SoundPlayer(Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    m2sp.Properties.Resources.CorrectSound));
            wrongSound = new SoundPlayer(Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    m2sp.Properties.Resources.WrongSound));
        }

        public static void PlayCorrectSound() {
            correctSound.Play();
        }

        public static void PlayWrongSound() {
            wrongSound.Play();
        }
    }
}
