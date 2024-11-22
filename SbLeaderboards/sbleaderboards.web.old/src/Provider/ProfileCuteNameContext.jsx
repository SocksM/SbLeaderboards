/* eslint-disable react/prop-types */
import { createContext, useContext } from "react";

const ProfileCuteNameContext = createContext();

export const profileCuteNameLabels = {
    0: "Apple",
    1: "Banana",
    2: "Blueberry",
    3: "Cucumber",
    4: "Coconut",
    5: "Grapes",
    6: "Kiwi",
    7: "Lemon",
    8: "Lime",
    9: "Mango",
    10: "Orange",
    11: "Papaya",
    12: "Pineapple",
    13: "Peach",
    14: "Pear",
    15: "Pomegranate",
    16: "Raspberry",
    17: "Strawberry",
    18: "Tomato",
    19: "Watermelon",
    20: "Zucchini"
};

export const ProfileCuteNameProvider = ({ children }) => {
    return (
        <ProfileCuteNameContext.Provider value={profileCuteNameLabels}>
            {children}
        </ProfileCuteNameContext.Provider>
    );
};

export const useProfileCuteNames = () => {
    return useContext(ProfileCuteNameContext);
};