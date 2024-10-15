import { useState, useEffect } from "react";
import { Table, Container } from "react-bootstrap";
import { useNightMode } from "../Provider/NightModeContext";
import LeaderboardTableHeader from "../Compoments/LeaderboardTableHeader";
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
                        <tr key={player.mcUuid}>
                            <td>
                                <Link to={`/Player/${player.mcUuid}`}>
                                    {`${player.name} (${player.profileName})`}
                                </Link>
                            </td>
                            <td>{formatSkyblockExp(player.stats.skyblockExp)}</td>
                            <td>{player.stats.tamingExp}</td>
                            <td>{player.stats.miningExp}</td>
                            <td>{player.stats.foragingExp}</td>
                            <td>{player.stats.enchantingExp}</td>
                            <td>{player.stats.carpentryExp}</td>
                            <td>{player.stats.farmingExp}</td>
                            <td>{player.stats.combatExp}</td>
                            <td>{player.stats.fishingExp}</td>
                            <td>{player.stats.alchemyExp}</td>
                            <td>{player.stats.runecraftingExp}</td>
                            <td>{player.stats.socialExp}</td>
                            <td>{player.stats.catacombsExp}</td>
                            <td>{player.stats.healerExp}</td>
                            <td>{player.stats.archerExp}</td>
                            <td>{player.stats.tankExp}</td>
                            <td>{player.stats.berserkerExp}</td>
                            <td>{player.stats.mageExp}</td>
                        </tr>
                    ))}
                </tbody>
            </Table>
        </Container>
    );
}

export default Leaderboard;