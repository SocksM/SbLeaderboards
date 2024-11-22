/* eslint-disable react/prop-types */
import { createContext, useContext } from "react";

const StatTypeContext = createContext();

export const statTypeLabels = {
    0: "SkyblockExp",
    1: "TamingExp",
    2: "MiningExp",
    3: "ForagingExp",
    4: "EnchantingExp",
    5: "CarpentryExp",
    6: "FarmingExp",
    7: "CombatExp",
    8: "FishingExp",
    9: "AlchemyExp",
    10: "RunecraftingExp",
    11: "SocialExp",
    12: "CatacombsExp",
    13: "HealerExp",
    14: "ArcherExp",
    15: "TankExp",
    16: "BerserkerExp",
    17: "MageExp",
};

export const StatTypeProvider = ({ children }) => {
    return (
        <StatTypeContext.Provider value={statTypeLabels}>
            {children}
        </StatTypeContext.Provider>
    );
};

export const useStatTypes = () => {
    return useContext(StatTypeContext);
};