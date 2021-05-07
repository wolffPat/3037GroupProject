/*
using System;
using System.Xml.Linq;
using Nucs.JsonSettings;

namespace MonsterDemo
{
    public class Property
    {
        private static SettingsBag _startSetting = JsonSettings.Load<SettingsBag>("MonsterCount.json").EnableAutosave();
        public static bool Hardmode { get; set; }

        dynamic _mcountProperty = _startSetting.AsDynamic();
        private long _count=0;
        
        public Monster MakeMonster()
        { 
            SettingsBag _settings = JsonSettings.Load<SettingsBag>("config.json").EnableAutosave();
        dynamic _mProperty = _settings.AsDynamic();

            
            Monster monster = new Monster();
            
            //if M count doesnt exist make it 0.
            if (_mcountProperty.mCount == null)
            {
                _mcountProperty.mCount = 0; _count = _mcountProperty.mCount;
            } 
           
          
            
            //will say it is never used but it is. This is to dynamically make/name each settings for each new monster 
            string mMaxHealth = "m" + _count + "MaxHealth";
            string mHealth = "m" + _count + "Health";
            string mName = "m" + _count + "Name";
            string mAttack = "m" + _count + "Attack";
            string mFriendhsip = "m" + _count + "Friendship";
            string mXp = "m" + _count + "Xp";
            string mMaxXp = "m" + _count + "MaxXp";
            
            if (_mProperty.mNewBorn == null||_mProperty.mNewBorn == "unborn")
            {
                string mNum = "m" + _count + "Number"; //gets and saves this monster number ex. m1number, m2number
                
                //add new monster to count
                _mcountProperty.mCount = (_mcountProperty.mCount) + 1;
                _count = _mcountProperty.mCount;
                // its first time making this monster so give them defaults
                _mProperty.mName = "Name";
                _mProperty.mHealth = 5;
                _mProperty.mMaxHealth = 5;
                _mProperty.mAttack = 0;
                _mProperty.mFriendhsip = 0;
                _mProperty.mXp = 0;
                _mProperty.mMaxXp = 1;

                // mNum is different than count because count is forever increasing, while mNum is specific to each monster 
                _mcountProperty.mNum = _count;

                //_mProperty.Challenge = 0;
                monster.MonsterName = _mProperty.mName;
                monster.MonsterMaxHealth = _mProperty.mMaxHealth;
                monster.MonsterHealth = _mProperty.mHealth;
                monster.MonsterAttack = _mProperty.mAttack;
                monster.MonsterFriendShip = _mProperty.mFriendhsip;
                monster.MonsterXp = _mProperty.mXp;
                monster.MonsterMaxXp = _mProperty.mMaxXp;
                monster.MonsterNumber = Convert.ToInt32(_count);

                //now will never reset to default // not null so will not do this again
                _mProperty.mNewBorn = "born";
                
            }
            else
            {
                //not first time making this monster so grab all its settings
                monster.MonsterName = Convert.ToString( _mProperty.mName);
                monster.MonsterMaxHealth =Convert.ToInt32( _mProperty.mMaxHealth);
                monster.MonsterHealth = Convert.ToInt32(_mProperty.mHealth);
                monster.MonsterAttack = Convert.ToInt32(_mProperty.mAttack);
                monster.MonsterFriendShip = Convert.ToInt32(_mProperty.mFriendhsip);
                monster.MonsterXp = Convert.ToInt32(_mProperty.mXp);
                monster.MonsterMaxXp = Convert.ToInt32(_mProperty.mMaxXp);
                
                // mNum is different than count because count is forever increasing, mNum is specific to each monster 
                monster.MonsterNumber = Convert.ToInt32(_mProperty.mNum);
            }
            return monster;
        }

        public void Save(Monster monster)
        {
            //not first time making this monster so grab all its settings
            SettingsBag _settings = JsonSettings.Load<SettingsBag>("config.json").EnableAutosave();
            dynamic _mProperty = _settings.AsDynamic();
            
            long mNum = monster.MonsterNumber;
            string mMaxHealth = "m" + mNum + "MaxHealth";
            string mHealth = "m" + mNum + "Health"; 
            string mName = "m" + mNum + "Name"; 
            string mAttack = "m" + mNum + "Attack";
            string mFriendhsip = "m" + mNum + "Friendship";
            string mXp = "m" + mNum + "Xp";
            string mMaxXp = "m" + mNum + "MaxXp";
                //save that monsters
            _mProperty.mName = monster.MonsterName; 
            _mProperty.mMaxHealth = monster.MonsterMaxHealth;
            _mProperty.mHealth = monster.MonsterHealth;
            _mProperty.mAttack = monster.MonsterAttack;
            _mProperty.mFriendhsip = monster.MonsterFriendShip;
            _mProperty.mXp = monster.MonsterXp;
            _mProperty.mMaxXp = monster.MonsterMaxXp; // mNum is different than count because count is forever increasing, mNum is specific to each monster 
            }
          
        }
    }
    */
    