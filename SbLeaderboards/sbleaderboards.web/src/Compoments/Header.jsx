import "react";
import { Form } from "react-bootstrap"; // Import Form for the toggle switch
import { useNightMode } from "../Provider/NightModeContext"; // Use the NightMode context

function Header() {
    const { isDarkMode, toggleDarkMode } = useNightMode(); // Access dark mode state and toggle function

    return (
        <header className={`transition d-flex justify-content-between align-items-center p-3 ${isDarkMode ? "bg-dark text-light" : "bg-light text-dark"}`}>
            <h2>Hypixel Skyblock Leaderboards</h2>
            <Form.Check
                type="switch"
                id="dark-mode-switch"
                label="Night Mode"
                checked={isDarkMode}
                onChange={toggleDarkMode} // Toggle dark mode on switch change
            />
        </header>
    );
}

export default Header;