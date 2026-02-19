using PreventPowerSave.CoreElements.State;
using System.Drawing;

namespace PreventPowerSave.CoreElements
{
    /// <summary>
    /// Central colour palette for the application.
    /// All forms and controls read from here — no hardcoded colours elsewhere.
    ///
    /// Light palette: clean Windows-style greys and whites.
    /// Dark palette:  Visual Studio dark theme inspired (#2D2D30 family).
    /// </summary>
    public static class Themes
    {
        public static THEMEMODE_STATE Mode => Controller.ConfigData.ThemeMode;
        private static bool IsDark => Mode == THEMEMODE_STATE.DarkMode;

        // ── Form / window surface ────────────────────────────────────────────
        /// <summary>Background colour for forms and panels.</summary>
        public static Color BackColor =>
            IsDark ? Color.FromArgb(45, 45, 48) : Color.FromArgb(240, 240, 240);

        // ── Text ─────────────────────────────────────────────────────────────
        /// <summary>Primary text colour.</summary>
        public static Color ForeColor =>
            IsDark ? Color.FromArgb(220, 220, 220) : Color.FromArgb(30, 30, 30);

        // ── Input fields (TextBox, ComboBox, NumericUpDown) ──────────────────
        /// <summary>
        /// Background for editable input controls — slightly lighter/darker than
        /// BackColor so inputs are visually distinguishable from the form surface.
        /// </summary>
        public static Color InputBackColor =>
            IsDark ? Color.FromArgb(63, 63, 70) : Color.White;

        // ── Buttons ──────────────────────────────────────────────────────────
        /// <summary>Border colour for flat buttons.</summary>
        public static Color BorderColor =>
            IsDark ? Color.FromArgb(85, 85, 90) : Color.FromArgb(173, 173, 173);

        /// <summary>Button background on mouse-over.</summary>
        public static Color HoverColor =>
            IsDark ? Color.FromArgb(62, 62, 66) : Color.FromArgb(213, 213, 213);

        // ── DataGridView ─────────────────────────────────────────────────────
        /// <summary>Empty area background of the grid.</summary>
        public static Color GridBackColor =>
            IsDark ? Color.FromArgb(37, 37, 38) : Color.FromArgb(200, 200, 200);

        /// <summary>Normal data-row background.</summary>
        public static Color GridRowBackColor =>
            IsDark ? Color.FromArgb(45, 45, 48) : Color.White;

        /// <summary>Alternating data-row background.</summary>
        public static Color GridRowAltBackColor =>
            IsDark ? Color.FromArgb(55, 55, 58) : Color.FromArgb(245, 245, 245);

        /// <summary>Data-row text colour.</summary>
        public static Color GridRowForeColor => ForeColor;

        /// <summary>Column- and row-header background.</summary>
        public static Color GridHeaderBackColor =>
            IsDark ? Color.FromArgb(30, 30, 30) : Color.FromArgb(50, 50, 50);

        /// <summary>Column- and row-header text (always white for contrast).</summary>
        public static Color GridHeaderForeColor => Color.White;

        /// <summary>Grid-line colour.</summary>
        public static Color GridLineColor =>
            IsDark ? Color.FromArgb(80, 80, 85) : Color.FromArgb(210, 210, 210);

        /// <summary>Selected-row highlight background.</summary>
        public static Color GridSelectionBackColor =>
            IsDark ? Color.FromArgb(60, 100, 160) : Color.FromArgb(0, 120, 215);

        /// <summary>Selected-row highlight text.</summary>
        public static Color GridSelectionForeColor => Color.White;
    }
}
