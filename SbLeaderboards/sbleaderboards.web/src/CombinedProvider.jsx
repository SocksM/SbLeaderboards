import "react";
import { NightModeProvider } from "./NightModeContext";
import PropTypes from "prop-types";

const CombinedProvider = ({ children }) => {
    return (
        <NightModeProvider>
                {children}
        </NightModeProvider>
    );
};

CombinedProvider.propTypes = {
    children: PropTypes.array
}

export default CombinedProvider;