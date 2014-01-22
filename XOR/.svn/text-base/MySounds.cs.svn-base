using System;
using System.Collections.Generic;
using System.Text;
using System.Media;

namespace XOR
{
    public class MySounds
    {
        public enum XorSound {explode, death, endlevel};

        SoundPlayer m_explodeP;
        SoundPlayer m_deathP;
        SoundPlayer m_endLevelP;
        Mci m_trackMci;

        bool m_playSounds = true;

        public bool PlaySounds
        {
            get { return m_playSounds; }
            set { m_playSounds = value; }
        }


        public static bool IsRunningOnMono()
        {
            return Type.GetType("Mono.Runtime") != null;
        }

        public MySounds(string dir, bool doplay)
        {
            if (IsRunningOnMono())
                return;

            m_trackMci = new Mci();
            m_explodeP = new SoundPlayer(dir + "explode.wav");
            m_deathP = new SoundPlayer(dir + "death.wav");
            m_endLevelP = new SoundPlayer(dir + "endlevel.wav");

            PlaySounds = doplay;

            try
            {
                if (doplay)
                {
                    m_trackMci.Open(dir + "strack.wav");
                    m_trackMci.Volume = 500;
                    m_trackMci.Play(true); // play repeatingly
                }
                    
            } 
            catch (Exception exc)
            {
            }

            try
            {
                m_explodeP.Load();
            }
            catch (Exception exc) { }

            try
            {
                m_deathP.Load();
            }
            catch (Exception exc)
            {
            }

            try
            {
                m_endLevelP.Load();
            }
            catch (Exception exc)
            {
            }
            
        }

        public void Play(XorSound sd)
        {
            if (IsRunningOnMono())
                return;

            if (!PlaySounds) return;

            switch (sd)
            {
                case XorSound.explode:
                    m_explodeP.Play();
                    break;
                case XorSound.death:
                    m_deathP.Play();
                    break;
                case XorSound.endlevel:
                    m_endLevelP.Play();
                    break;
            }
        }

        public void IncreaseVolume() {

            if (IsRunningOnMono())
                return;

            m_trackMci.Volume += 100;
           
        }

        public void DecreaseVolume()
        {
            if (IsRunningOnMono())
                return;

           m_trackMci.Volume -= 100;
        }

        internal void StopBgMusic()
        {

            if (IsRunningOnMono())
                return;

            m_trackMci.Stop();
            m_trackMci.Close();
        }
    }
}
