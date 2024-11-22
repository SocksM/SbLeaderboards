/* eslint-disable react/prop-types */
import { createContext, useContext } from "react";

const ProfileTypeContext = createContext();

export const profileTypeLabels = {
    0: "Regular",
    1: "Ironman",
    2: "Bingo",
    3: "Stranded"
};

export const ProfileTypeProvider = ({ children }) => {
    return (
        <ProfileTypeContext.Provider value={profileTypeLabels}>
            {children}
        </ProfileTypeContext.Provider>
    );
};

export const useProfileTypes = () => {
    return useContext(ProfileTypeContext);
};