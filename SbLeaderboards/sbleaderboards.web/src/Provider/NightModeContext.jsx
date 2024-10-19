import { createContext, useContext, useState, useEffect } from "react";
import PropTypes from "prop-types";


const NightModeContext = createContext();

export const NightModeProvider = ({ children }) => {
    const [isDarkMode, setIsDarkMode] = useState(true); // Set default mode as dark

    const toggleDarkMode = () => {
        setIsDarkMode((prevMode) => !prevMode);
    };

    useEffect(() => {
        if (isDarkMode) {
            document.body.classList.add("bg-dark");
            document.body.classList.remove("bg-light");
        } else {
            document.body.classList.add("bg-light");
            document.body.classList.remove("bg-dark");
        }
    }, [isDarkMode]);

    return (
        <NightModeContext.Provider value={{ isDarkMode, toggleDarkMode }}>
            {children}
        </NightModeContext.Provider>
    );
};

NightModeProvider.propTypes = {
    children: PropTypes.array
}


export const useNightMode = () => {
    return useContext(NightModeContext);
};