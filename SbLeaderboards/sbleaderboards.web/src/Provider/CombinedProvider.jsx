import "react";
import { NightModeProvider } from "./NightModeContext";
import { ProfileTypeProvider } from "./ProfileTypeContext";
import { ProfileCuteNameProvider } from "./ProfileCuteNameContext";
import { StatTypeProvider } from "./StatTypeContext";
import PropTypes from "prop-types";

const CombinedProvider = ({ children }) => {
    return (
        <ProfileTypeProvider>
            <StatTypeProvider>
                <ProfileCuteNameProvider>
                    <NightModeProvider>
                        {children}
                    </NightModeProvider>
                </ProfileCuteNameProvider>
            </StatTypeProvider>
        </ProfileTypeProvider>
    );
};

CombinedProvider.propTypes = {
    children: PropTypes.array
}

export default CombinedProvider;