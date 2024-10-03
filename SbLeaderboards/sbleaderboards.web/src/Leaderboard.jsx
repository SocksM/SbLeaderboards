import { useState, useEffect } from "react";
//import "./Leaderboard.css"; // Import the CSS file for styling


function Leaderboard() {
    const [leaderboard, setLeaderboard] = useState([]);
    const [sortKey, setSortKey] = useState(""); // Keeps track of which exp value to sort by
    const [isAscending, setIsAscending] = useState(true); // Track sorting order

    useEffect(() => {
        // Fetch leaderboard data from the API
        fetch("https://localhost:7073/api/Leaderboard")
            .then((response) => response.json())
            .then((data) => {
                // Convert the object to an array to make it easier to handle sorting
                const formattedData = Object.keys(data).map((key) => ({
                    name: key,
                    ...data[key],
                }));
                setLeaderboard(formattedData);
            })
            .catch((error) => console.error("Error fetching leaderboard:", error));
    }, []);

    const handleSort = (key) => {
        const sortedData = [...leaderboard].sort((a, b) => {
            if (isAscending) {
                return a[key] - b[key];
            } else {
                return b[key] - a[key];
            }
        });
        setIsAscending(!isAscending);
        setSortKey(key);
        setLeaderboard(sortedData);
    };

    return (
        <div>
            <h2>Leaderboard</h2>
            <table>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th onClick={() => handleSort("skyblockExp")}>Skyblock Exp</th>
                        <th onClick={() => handleSort("tamingExp")}>Taming Exp</th>
                        <th onClick={() => handleSort("miningExp")}>Mining Exp</th>
                        <th onClick={() => handleSort("foragingExp")}>Foraging Exp</th>
                        <th onClick={() => handleSort("enchantingExp")}>Enchanting Exp</th>
                        <th onClick={() => handleSort("carpentryExp")}>Carpentry Exp</th>
                        <th onClick={() => handleSort("farmingExp")}>Farming Exp</th>
                        <th onClick={() => handleSort("combatExp")}>Combat Exp</th>
                        <th onClick={() => handleSort("fishingExp")}>Fishing Exp</th>
                        <th onClick={() => handleSort("alchemyExp")}>Alchemy Exp</th>
                        <th onClick={() => handleSort("runecraftingExp")}>Runecrafting Exp</th>
                        <th onClick={() => handleSort("socialExp")}>Social Exp</th>
                        <th onClick={() => handleSort("catacombsExp")}>Catacombs Exp</th>
                        <th onClick={() => handleSort("healerExp")}>Healer Exp</th>
                        <th onClick={() => handleSort("archerExp")}>Archer Exp</th>
                        <th onClick={() => handleSort("tankExp")}>Tank Exp</th>
                        <th onClick={() => handleSort("berserkerExp")}>Berserker Exp</th>
                        <th onClick={() => handleSort("mageExp")}>Mage Exp</th>
                    </tr>
                </thead>
                <tbody>
                    {leaderboard.map((player) => (
                        <tr key={player.profileId}>
                            <td>{player.name}</td>
                            <td>{player.skyblockExp}</td>
                            <td>{player.tamingExp}</td>
                            <td>{player.miningExp}</td>
                            <td>{player.foragingExp}</td>
                            <td>{player.enchantingExp}</td>
                            <td>{player.carpentryExp}</td>
                            <td>{player.farmingExp}</td>
                            <td>{player.combatExp}</td>
                            <td>{player.fishingExp}</td>
                            <td>{player.alchemyExp}</td>
                            <td>{player.runecraftingExp}</td>
                            <td>{player.socialExp}</td>
                            <td>{player.catacombsExp}</td>
                            <td>{player.healerExp}</td>
                            <td>{player.archerExp}</td>
                            <td>{player.tankExp}</td>
                            <td>{player.berserkerExp}</td>
                            <td>{player.mageExp}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}

export default Leaderboard;
