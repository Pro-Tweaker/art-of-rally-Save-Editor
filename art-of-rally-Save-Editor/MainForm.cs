using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using art_of_rally_Save_Editor.Game;
using art_of_rally_Save_Editor.Utils;

namespace art_of_rally_Save_Editor
{
    public partial class MainForm : Form
    {
        public const string CLOUD_SAVE_FILENAME = "SaveGame.json";

        private List<SaveEntry> saveEntries;
        private BindingSource bindingSource = new BindingSource();

        string fileName;

        public MainForm()
        {
            InitializeComponent();

            DisableButtons();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            AddValues();

            valuesToolStripComboBox.DropDownWidth = valuesToolStripComboBox.AutoDropDownWidth();
        }

        private void LoadLocal()
        {
            fileName = Path.Combine(SpecialFolder.GetPath(SpecialFolder.KnownFolder.LocalAppDataLow), "Funselektor Labs", "art of rally", "cloud", CLOUD_SAVE_FILENAME);

            if (!File.Exists(fileName))
            {
                MessageBox.Show("Save not found !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                LoadFile(fileName);
            }
        }

        private void LoadFile(string path)
        {
            using (StreamReader file = File.OpenText(path))
            {
                saveEntries = ((SaveEntry[])new JsonSerializer().Deserialize(file, typeof(SaveEntry[]))).ToList();
            }

            if (saveEntries.Count > 0)
            {
                bindingSource.DataSource = saveEntries;
                dataGridView1.DataSource = bindingSource;

                dataGridView1.Columns[1].Width = 75;
                dataGridView1.Columns[0].ReadOnly = true;
                dataGridView1.Columns[1].ReadOnly = false;

                EnableButtons();
            }
        }

        private void SaveLocal()
        {
            BackupLocal(fileName);

            string json = JsonConvert.SerializeObject(saveEntries, Formatting.Indented);

            File.WriteAllText(fileName, json);

            MessageBox.Show("File saved !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BackupLocal(string fileName)
        {
            string timeStamp = DateUtils.GetTimestamp(DateTime.Now);

            File.Copy(fileName, fileName + "_" + timeStamp);
        }

        private void UnlockAll()
        {
            AddIfNotPresent(saveEntries, new SaveEntry("FREEROAM_LEVEL_UNLOCKED_SARDINIA", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("FREEROAM_LEVEL_UNLOCKED_GERMANY", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("FREEROAM_LEVEL_UNLOCKED_NORWAY", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("FREEROAM_LEVEL_UNLOCKED_JAPAN", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("FREEROAM_LEVEL_UNLOCKED_KENYA", 1));

            AddIfNotPresent(saveEntries, new SaveEntry("SONG_UNLOCK_FINLAND", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("SONG_UNLOCK_GERMANY", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("SONG_UNLOCK_NORWAY", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("SONG_UNLOCK_JAPAN", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("SONG_UNLOCK_SARDINIA", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("SONG_UNLOCK_KENYA", 1));

            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1967", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1968", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1969", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1970", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1971", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1972", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1973", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1974", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1975", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1976", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1977", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1978", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1979", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1980", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1981", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1982", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1983", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1984", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1985", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1986", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1987", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1988", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1989", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1990", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1991", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1992", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1993", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1994", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1995", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1996", 1));

            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1967_BONUS", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1968_BONUS", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1969_BONUS", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1970_BONUS", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1971_BONUS", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1972_BONUS", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1973_BONUS", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1974_BONUS", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1975_BONUS", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1976_BONUS", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1977_BONUS", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1978_BONUS", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1979_BONUS", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1980_BONUS", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1981_BONUS", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1982_BONUS", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1983_BONUS", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1984_BONUS", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1985_BONUS", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1986_BONUS", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1987_BONUS", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1988_BONUS", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1989_BONUS", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1990_BONUS", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1991_BONUS", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1992_BONUS", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1993_BONUS", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1994_BONUS", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1995_BONUS", 1));
            AddIfNotPresent(saveEntries, new SaveEntry("UNLOCKABLE_1996_BONUS", 1));

            SaveLocal();
        }

        private void AddIfNotPresent(List<SaveEntry> list, SaveEntry saveEntry, bool showError = false)
        {
            bool contains = list.Any(p => p.Key == saveEntry.Key);

            if (contains)
            {
                if (showError)
                {
                    MessageBox.Show("Value already exists in the table !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                list.Add(saveEntry);

                bindingSource.ResetBindings(false);
            }
        }

        private void AddValues()
        {
            valuesToolStripComboBox.Items.Add("SELECTED_GHOST_FILTER");
            valuesToolStripComboBox.Items.Add("SHOW_INTRO_MAIN_MENU");
            valuesToolStripComboBox.Items.Add("HAS_PLAYED_INTRODUCTION");
            valuesToolStripComboBox.Items.Add("PLAY_COMPLETE_CUTSCENE");
            valuesToolStripComboBox.Items.Add("SHOWN_CAREER_INTRO");
            valuesToolStripComboBox.Items.Add("GAME_COMPLETE");
            valuesToolStripComboBox.Items.Add("HAS_SEEN_PRIVACY_POLICY");           
            valuesToolStripComboBox.Items.Add("TUTORIAL_NUMBER");
            valuesToolStripComboBox.Items.Add("SAVE_VERSION_NUMBER");
            valuesToolStripComboBox.Items.Add("HAS_RESET_PLAYERPREFS");
            valuesToolStripComboBox.Items.Add("CURRENT_LEADERBOARD_ENUM");
            valuesToolStripComboBox.Items.Add("GAME_SETTINGS_GDPR_SETTING");
            valuesToolStripComboBox.Items.Add("SETTINGS_QUALITY_LEVEL");
            valuesToolStripComboBox.Items.Add("SETTINGS_GAMMA");
            valuesToolStripComboBox.Items.Add("SETTINGS_FULLSCREEN");
            valuesToolStripComboBox.Items.Add("SETTINGS_AA");
            valuesToolStripComboBox.Items.Add("SETTINGS_SSAO");
            valuesToolStripComboBox.Items.Add("SETTINGS_BLOOM");
            valuesToolStripComboBox.Items.Add("SETTINGS_DISTANCE_BLUR");
            valuesToolStripComboBox.Items.Add("SETTINGS_FILM_GRAIN");
            valuesToolStripComboBox.Items.Add("SETTINGS_MOTION_BLUR");
            valuesToolStripComboBox.Items.Add("SETTINGS_SHADOW_RESOLUTION");
            valuesToolStripComboBox.Items.Add("SETTINGS_SHADOW_DISTANCE");
            valuesToolStripComboBox.Items.Add("SETTINGS_VOLUMETRIC_LIGHT");
            valuesToolStripComboBox.Items.Add("SETTINGS_PARTICLE_QUALITY");
            valuesToolStripComboBox.Items.Add("SETTINGS_VEGETATION_DISTANCE");
            valuesToolStripComboBox.Items.Add("SETTINGS_CROWD_DENSITY");
            valuesToolStripComboBox.Items.Add("SETTINGS_VSYNC");
            valuesToolStripComboBox.Items.Add("SETTINGS_FRAMERATE_CAP");
            valuesToolStripComboBox.Items.Add("SETTINGS_RESOLUTION_WIDTH");
            valuesToolStripComboBox.Items.Add("SETTINGS_RESOLUTION_HEIGHT");
            valuesToolStripComboBox.Items.Add("SETTINGS_RESOLUTION_AUTO");
            valuesToolStripComboBox.Items.Add("SETTINGS_INITIAL_SETUP");
            valuesToolStripComboBox.Items.Add("SETTINGS_SPLASH_SCREEN");
            valuesToolStripComboBox.Items.Add("SETTINGS_CAMERA_FOV");
            valuesToolStripComboBox.Items.Add("SETTINGS_CAMERA_PRESET");
            valuesToolStripComboBox.Items.Add("SETTINGS_CAMERA_ROTATION_DAMPING");
            valuesToolStripComboBox.Items.Add("SETTINGS_CAMERA_SHAKE");
            valuesToolStripComboBox.Items.Add("SETTINGS_MASTER_VOLUME");
            valuesToolStripComboBox.Items.Add("SETTINGS_MUSIC_VOLUME");
            valuesToolStripComboBox.Items.Add("SETTINGS_UI_VOLUME");
            valuesToolStripComboBox.Items.Add("SETTINGS_AMBIENCE_VOLUME");
            valuesToolStripComboBox.Items.Add("SETTINGS_EFFECTS_VOLUME");
            valuesToolStripComboBox.Items.Add("SETTINGS_ENGINE_VOLUME");
            valuesToolStripComboBox.Items.Add("SETTINGS_VIBRATION");
            valuesToolStripComboBox.Items.Add("SETTINGS_STEERING_SENSITIVITY");
            valuesToolStripComboBox.Items.Add("SETTINGS_THROTTLE_SENSITIVITY");
            valuesToolStripComboBox.Items.Add("SETTINGS_BRAKING_SENSITIVITY");
            valuesToolStripComboBox.Items.Add("SETTINGS_STEERING_DEADZONE");
            valuesToolStripComboBox.Items.Add("SETTINGS_THROTTLE_DEADZONE");
            valuesToolStripComboBox.Items.Add("SETTINGS_BRAKING_DEADZONE");
            valuesToolStripComboBox.Items.Add("SETTINGS_STEER_ASSIST");
            valuesToolStripComboBox.Items.Add("SETTINGS_STABILITY_ASSIST");
            valuesToolStripComboBox.Items.Add("SETTINGS_STEER_CORRECTION");
            valuesToolStripComboBox.Items.Add("SETTINGS_SPEED_SENSITIVITY");
            valuesToolStripComboBox.Items.Add("SETTINGS_TRANSMISSION");
            valuesToolStripComboBox.Items.Add("SETTINGS_ABS");
            valuesToolStripComboBox.Items.Add("SETTINGS_DIFFICULTY");
            valuesToolStripComboBox.Items.Add("SETTINGS_LANGUAGE");
            valuesToolStripComboBox.Items.Add("SETTINGS_SPEED_UNITS");
            valuesToolStripComboBox.Items.Add("SETTINGS_ACTUAL_SPEEDOMETER");
            valuesToolStripComboBox.Items.Add("SETTINGS_SPEEDOMETER");
            valuesToolStripComboBox.Items.Add("SETTINGS_TIMERS");
            valuesToolStripComboBox.Items.Add("SETTINGS_STAGE_PROGRESS");
            valuesToolStripComboBox.Items.Add("SETTINGS_SPLIT_TIMES");
            valuesToolStripComboBox.Items.Add("SETTINGS_COUNTRY");
            valuesToolStripComboBox.Items.Add("SETTINGS_BLOOD_TYPE");
            valuesToolStripComboBox.Items.Add("SETTINGS_HORN");
            valuesToolStripComboBox.Items.Add("SETTINGS_CAREER_AI_DIFFICULTY");
            valuesToolStripComboBox.Items.Add("SETTINGS_CAREER_DAMAGE_LEVEL");
            valuesToolStripComboBox.Items.Add("SETTINGS_CUSTOM_RALLY_AI_DIFFICULTY");
            valuesToolStripComboBox.Items.Add("SETTINGS_CUSTOM_RALLY_DAMAGE_LEVEL");
            valuesToolStripComboBox.Items.Add("SETTINGS_FREEROAM_PROGRESS");
            valuesToolStripComboBox.Items.Add("SETTINGS_VEGETATION_CUTOUT");
            valuesToolStripComboBox.Items.Add("SETTINGS_VEGETATION_RENDER_TYPE");
            valuesToolStripComboBox.Items.Add("SETTINGS_GHOSTS");
            valuesToolStripComboBox.Items.Add("SETTINGS_RUN_IN_BACKGROUND");
            valuesToolStripComboBox.Items.Add("SETTINGS_APPLICATION_PATH");
            valuesToolStripComboBox.Items.Add("SETTINGS_DARK_MODE");
            valuesToolStripComboBox.Items.Add("SETTINGS_UI_SCALE");
            valuesToolStripComboBox.Items.Add("SETTINGS_DYNAMIC_SCALING");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1967");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1968");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1969");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1970");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1971");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1972");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1973");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1974");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1975");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1976");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1977");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1978");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1979");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1980");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1981");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1982");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1983");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1984");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1985");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1986");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1987");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1988");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1989");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1990");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1991");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1992");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1993");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1994");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1995");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1996");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1967_BONUS");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1968_BONUS");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1969_BONUS");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1970_BONUS");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1971_BONUS");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1972_BONUS");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1973_BONUS");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1974_BONUS");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1975_BONUS");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1976_BONUS");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1977_BONUS");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1978_BONUS");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1979_BONUS");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1980_BONUS");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1981_BONUS");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1982_BONUS");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1983_BONUS");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1984_BONUS");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1985_BONUS");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1986_BONUS");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1987_BONUS");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1988_BONUS");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1989_BONUS");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1990_BONUS");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1991_BONUS");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1992_BONUS");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1993_BONUS");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1994_BONUS");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1995_BONUS");
            valuesToolStripComboBox.Items.Add("UNLOCKABLE_1996_BONUS");
            valuesToolStripComboBox.Items.Add("FREEROAM_FINLAND_VAN_0");
            valuesToolStripComboBox.Items.Add("FREEROAM_FINLAND_TAPE_0");
            valuesToolStripComboBox.Items.Add("FREEROAM_FINLAND_TAPE_1");
            valuesToolStripComboBox.Items.Add("FREEROAM_FINLAND_TAPE_2");
            valuesToolStripComboBox.Items.Add("FREEROAM_FINLAND_TAPE_3");
            valuesToolStripComboBox.Items.Add("FREEROAM_FINLAND_TAPE_4");
            valuesToolStripComboBox.Items.Add("FREEROAM_FINLAND_RALLY_0");
            valuesToolStripComboBox.Items.Add("FREEROAM_FINLAND_RALLY_1");
            valuesToolStripComboBox.Items.Add("FREEROAM_FINLAND_RALLY_2");
            valuesToolStripComboBox.Items.Add("FREEROAM_FINLAND_RALLY_3");
            valuesToolStripComboBox.Items.Add("FREEROAM_FINLAND_RALLY_4");
            valuesToolStripComboBox.Items.Add("FREEROAM_FINLAND_VIEW_0");
            valuesToolStripComboBox.Items.Add("FREEROAM_FINLAND_VIEW_1");
            valuesToolStripComboBox.Items.Add("FREEROAM_FINLAND_VIEW_2");
            valuesToolStripComboBox.Items.Add("FREEROAM_FINLAND_VIEW_3");
            valuesToolStripComboBox.Items.Add("FREEROAM_FINLAND_VIEW_4");
            valuesToolStripComboBox.Items.Add("FREEROAM_GERMANY_VAN_0");
            valuesToolStripComboBox.Items.Add("FREEROAM_GERMANY_TAPE_0");
            valuesToolStripComboBox.Items.Add("FREEROAM_GERMANY_TAPE_1");
            valuesToolStripComboBox.Items.Add("FREEROAM_GERMANY_TAPE_2");
            valuesToolStripComboBox.Items.Add("FREEROAM_GERMANY_TAPE_3");
            valuesToolStripComboBox.Items.Add("FREEROAM_GERMANY_TAPE_4");
            valuesToolStripComboBox.Items.Add("FREEROAM_GERMANY_RALLY_0");
            valuesToolStripComboBox.Items.Add("FREEROAM_GERMANY_RALLY_1");
            valuesToolStripComboBox.Items.Add("FREEROAM_GERMANY_RALLY_2");
            valuesToolStripComboBox.Items.Add("FREEROAM_GERMANY_RALLY_3");
            valuesToolStripComboBox.Items.Add("FREEROAM_GERMANY_RALLY_4");
            valuesToolStripComboBox.Items.Add("FREEROAM_GERMANY_VIEW_0");
            valuesToolStripComboBox.Items.Add("FREEROAM_GERMANY_VIEW_1");
            valuesToolStripComboBox.Items.Add("FREEROAM_GERMANY_VIEW_2");
            valuesToolStripComboBox.Items.Add("FREEROAM_GERMANY_VIEW_3");
            valuesToolStripComboBox.Items.Add("FREEROAM_GERMANY_VIEW_4");
            valuesToolStripComboBox.Items.Add("FREEROAM_JAPAN_VAN_0");
            valuesToolStripComboBox.Items.Add("FREEROAM_JAPAN_TAPE_0");
            valuesToolStripComboBox.Items.Add("FREEROAM_JAPAN_TAPE_1");
            valuesToolStripComboBox.Items.Add("FREEROAM_JAPAN_TAPE_2");
            valuesToolStripComboBox.Items.Add("FREEROAM_JAPAN_TAPE_3");
            valuesToolStripComboBox.Items.Add("FREEROAM_JAPAN_TAPE_4");
            valuesToolStripComboBox.Items.Add("FREEROAM_JAPAN_RALLY_0");
            valuesToolStripComboBox.Items.Add("FREEROAM_JAPAN_RALLY_1");
            valuesToolStripComboBox.Items.Add("FREEROAM_JAPAN_RALLY_2");
            valuesToolStripComboBox.Items.Add("FREEROAM_JAPAN_RALLY_3");
            valuesToolStripComboBox.Items.Add("FREEROAM_JAPAN_RALLY_4");
            valuesToolStripComboBox.Items.Add("FREEROAM_JAPAN_VIEW_0");
            valuesToolStripComboBox.Items.Add("FREEROAM_JAPAN_VIEW_1");
            valuesToolStripComboBox.Items.Add("FREEROAM_JAPAN_VIEW_2");
            valuesToolStripComboBox.Items.Add("FREEROAM_JAPAN_VIEW_3");
            valuesToolStripComboBox.Items.Add("FREEROAM_JAPAN_VIEW_4");
            valuesToolStripComboBox.Items.Add("FREEROAM_NORWAY_VAN_0");
            valuesToolStripComboBox.Items.Add("FREEROAM_NORWAY_TAPE_0");
            valuesToolStripComboBox.Items.Add("FREEROAM_NORWAY_TAPE_1");
            valuesToolStripComboBox.Items.Add("FREEROAM_NORWAY_TAPE_2");
            valuesToolStripComboBox.Items.Add("FREEROAM_NORWAY_TAPE_3");
            valuesToolStripComboBox.Items.Add("FREEROAM_NORWAY_TAPE_4");
            valuesToolStripComboBox.Items.Add("FREEROAM_NORWAY_RALLY_0");
            valuesToolStripComboBox.Items.Add("FREEROAM_NORWAY_RALLY_1");
            valuesToolStripComboBox.Items.Add("FREEROAM_NORWAY_RALLY_2");
            valuesToolStripComboBox.Items.Add("FREEROAM_NORWAY_RALLY_3");
            valuesToolStripComboBox.Items.Add("FREEROAM_NORWAY_RALLY_4");
            valuesToolStripComboBox.Items.Add("FREEROAM_NORWAY_VIEW_0");
            valuesToolStripComboBox.Items.Add("FREEROAM_NORWAY_VIEW_1");
            valuesToolStripComboBox.Items.Add("FREEROAM_NORWAY_VIEW_2");
            valuesToolStripComboBox.Items.Add("FREEROAM_NORWAY_VIEW_3");
            valuesToolStripComboBox.Items.Add("FREEROAM_NORWAY_VIEW_4");
            valuesToolStripComboBox.Items.Add("FREEROAM_SARDINIA_VAN_0");
            valuesToolStripComboBox.Items.Add("FREEROAM_SARDINIA_TAPE_0");
            valuesToolStripComboBox.Items.Add("FREEROAM_SARDINIA_TAPE_1");
            valuesToolStripComboBox.Items.Add("FREEROAM_SARDINIA_TAPE_2");
            valuesToolStripComboBox.Items.Add("FREEROAM_SARDINIA_TAPE_3");
            valuesToolStripComboBox.Items.Add("FREEROAM_SARDINIA_TAPE_4");
            valuesToolStripComboBox.Items.Add("FREEROAM_SARDINIA_RALLY_0");
            valuesToolStripComboBox.Items.Add("FREEROAM_SARDINIA_RALLY_1");
            valuesToolStripComboBox.Items.Add("FREEROAM_SARDINIA_RALLY_2");
            valuesToolStripComboBox.Items.Add("FREEROAM_SARDINIA_RALLY_3");
            valuesToolStripComboBox.Items.Add("FREEROAM_SARDINIA_RALLY_4");
            valuesToolStripComboBox.Items.Add("FREEROAM_SARDINIA_VIEW_0");
            valuesToolStripComboBox.Items.Add("FREEROAM_SARDINIA_VIEW_1");
            valuesToolStripComboBox.Items.Add("FREEROAM_SARDINIA_VIEW_2");
            valuesToolStripComboBox.Items.Add("FREEROAM_SARDINIA_VIEW_3");
            valuesToolStripComboBox.Items.Add("FREEROAM_SARDINIA_VIEW_4");
            valuesToolStripComboBox.Items.Add("FREEROAM_KENYA_VAN_0");
            valuesToolStripComboBox.Items.Add("FREEROAM_KENYA_TAPE_0");
            valuesToolStripComboBox.Items.Add("FREEROAM_KENYA_TAPE_1");
            valuesToolStripComboBox.Items.Add("FREEROAM_KENYA_TAPE_2");
            valuesToolStripComboBox.Items.Add("FREEROAM_KENYA_TAPE_3");
            valuesToolStripComboBox.Items.Add("FREEROAM_KENYA_TAPE_4");
            valuesToolStripComboBox.Items.Add("FREEROAM_KENYA_RALLY_0");
            valuesToolStripComboBox.Items.Add("FREEROAM_KENYA_RALLY_1");
            valuesToolStripComboBox.Items.Add("FREEROAM_KENYA_RALLY_2");
            valuesToolStripComboBox.Items.Add("FREEROAM_KENYA_RALLY_3");
            valuesToolStripComboBox.Items.Add("FREEROAM_KENYA_RALLY_4");
            valuesToolStripComboBox.Items.Add("FREEROAM_KENYA_VIEW_0");
            valuesToolStripComboBox.Items.Add("FREEROAM_KENYA_VIEW_1");
            valuesToolStripComboBox.Items.Add("FREEROAM_KENYA_VIEW_2");
            valuesToolStripComboBox.Items.Add("FREEROAM_KENYA_VIEW_3");
            valuesToolStripComboBox.Items.Add("FREEROAM_KENYA_VIEW_4");
            valuesToolStripComboBox.Items.Add("FREEROAM_TOTAL_DISTANCE");
            valuesToolStripComboBox.Items.Add("FREEROAM_TOTAL_AIRTIME");
            valuesToolStripComboBox.Items.Add("FREEROAM_TOPSPEED");
            valuesToolStripComboBox.Items.Add("SONG_UNLOCK_FINLAND");
            valuesToolStripComboBox.Items.Add("SONG_UNLOCK_GERMANY");
            valuesToolStripComboBox.Items.Add("SONG_UNLOCK_NORWAY");
            valuesToolStripComboBox.Items.Add("SONG_UNLOCK_JAPAN");
            valuesToolStripComboBox.Items.Add("SONG_UNLOCK_SARDINIA");
            valuesToolStripComboBox.Items.Add("SONG_UNLOCK_KENYA");
            valuesToolStripComboBox.Items.Add("FREEROAM_LEVEL_UNLOCKED_SARDINIA");
            valuesToolStripComboBox.Items.Add("FREEROAM_LEVEL_UNLOCKED_GERMANY");
            valuesToolStripComboBox.Items.Add("FREEROAM_LEVEL_UNLOCKED_NORWAY");
            valuesToolStripComboBox.Items.Add("FREEROAM_LEVEL_UNLOCKED_JAPAN");
            valuesToolStripComboBox.Items.Add("FREEROAM_LEVEL_UNLOCKED_KENYA");
        }

        private void EnableButtons()
        {
            saveToolStripButton.Enabled = true;
            unlockAllToolStripButton.Enabled = true;
            valuesToolStripComboBox.Enabled = true;
            addValueToolStripButton.Enabled = true;
        }

        private void DisableButtons()
        {
            saveToolStripButton.Enabled = false;
            unlockAllToolStripButton.Enabled = false;
            valuesToolStripComboBox.Enabled = false;
            addValueToolStripButton.Enabled = false;
        }

        private void OpenWebsite()
        {
            DialogResult dialogResult = MessageBox.Show("Would you like to visit the website ?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                Process.Start("https://github.com/Pro-Tweaker/art-of-rally-Save-Editor");
            }
        }

        private void loadToolStripButton_Click(object sender, EventArgs e)
        {
            LoadLocal();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveLocal();
        }

        private void unlockAllToolStripButton_Click(object sender, EventArgs e)
        {
            UnlockAll();
        }

        private void addValueToolStripButton_Click(object sender, EventArgs e)
        {
            int index = valuesToolStripComboBox.SelectedIndex;

            if (index != -1)
            {
                string selected = (string)valuesToolStripComboBox.Items[index];

                SaveEntry saveEntry = new SaveEntry();

                saveEntry.Key = selected;

                AddIfNotPresent(saveEntries, saveEntry, true);
            }
        }

        private void aboutToolStripButton_Click(object sender, EventArgs e)
        {
            OpenWebsite();
        }
    }
}
