import { useState, useEffect } from "react";
import { Table, Container } from "react-bootstrap";
import { useNightMode } from "./NightModeContext";
import LeaderboardTableHeader from "./LeaderboardTableHeader";
import { Link } from "react-router-dom"; // Import Link

function Leaderboard() {
    const [leaderboard, setLeaderboard] = useState([]);
    const [sortKey, setSortKey] = useState("");
    const [isAscending, setIsAscending] = useState(true);
    const { isDarkMode } = useNightMode();

    useEffect(() => {
        fetch("https://localhost:7073/api/Leaderboard")
            .then((response) => response.json())
            .then((data) => {
                const formattedData = Object.keys(data).map((key) => ({
                    name: key,
                    ...data[key],
                }));
                setLeaderboard(formattedData);
            })
            .catch((error) => console.error("Error fetching leaderboard:", error));
    }, []);

    const handleSort = (key) => {
        const sortedData = [...leaderboard].sort((a, b) => (isAscending ? a[key] - b[key] : b[key] - a[key]));
        setIsAscending(!isAscending);
        setSortKey(key);
        setLeaderboard(sortedData);
    };

    const formatSkyblockExp = (exp) => {
        return (exp / 100).toFixed(2);
    };

    const expTypes = [
        "skyblockExp", "tamingExp", "miningExp", "foragingExp", "enchantingExp", "carpentryExp",
        "farmingExp", "combatExp", "fishingExp", "alchemyExp", "runecraftingExp", "socialExp",
        "catacombsExp", "healerExp", "archerExp", "tankExp", "berserkerExp", "mageExp"
    ];

    return (
        <Container className={`mt-4 transition ${isDarkMode ? "bg-dark text-light" : "bg-light text-dark"} w-100`}>
            <Table striped hover responsive className={`transition ${isDarkMode ? "table-dark" : "table-light"}`}>
                <thead className="w-100">
                    <tr>
                        <th>Name</th>
                        {expTypes.map((expType) => (
                            <LeaderboardTableHeader
                                key={expType}
                                expType={expType}
                                sortKey={sortKey}
                                isAscending={isAscending}
                                isDarkMode={isDarkMode}
                                handleSort={handleSort}
                            />
                        ))}
                    </tr>
                </thead>
                <tbody>
                    {leaderboard.map((player) => (
                        <tr key={player.profileId}>
                            <td>
                                <Link to={`/Player/${player.profileId}`}>{player.name}</Link> {/* Link to player page */}
                            </td>
                            <td>{formatSkyblockExp(player.skyblockExp)}</td>
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
            </Table>
        </Container>
    );
}

export default Leaderboard;