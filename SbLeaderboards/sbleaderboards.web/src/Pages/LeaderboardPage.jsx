import { useState, useEffect } from "react";
import { Table, Container } from "react-bootstrap";
import { useNightMode } from "../Provider/NightModeContext";
import LeaderboardTableHeader from "../Compoments/LeaderboardTableHeader"
import { Link } from "react-router-dom";

function Leaderboard() {
    const [leaderboard, setLeaderboard] = useState([]);
    const [sortKey, setSortKey] = useState("skyblockExp"); // Default to skyblockExp
    const [isDescending, setIsDescending] = useState(true);
    const { isDarkMode } = useNightMode();

    const statTypes = [
        { name: "skyblockExp", id: 0 },
        { name: "tamingExp", id: 1 },
        { name: "miningExp", id: 2 },
        { name: "foragingExp", id: 3 },
        { name: "enchantingExp", id: 4 },
        { name: "carpentryExp", id: 5 },
        { name: "farmingExp", id: 6 },
        { name: "combatExp", id: 7 },
        { name: "fishingExp", id: 8 },
        { name: "alchemyExp", id: 9 },
        { name: "runecraftingExp", id: 10 },
        { name: "socialExp", id: 11 },
        { name: "catacombsExp", id: 12 },
        { name: "healerExp", id: 13 },
        { name: "archerExp", id: 14 },
        { name: "tankExp", id: 15 },
        { name: "berserkerExp", id: 16 },
        { name: "mageExp", id: 17 }
    ];

    useEffect(() => {
        fetchLeaderboard(sortKey, isDescending);
    }, [sortKey, isDescending]);

    const fetchLeaderboard = (key, descending) => {
        const sortOrder = descending ? "true" : "false";
        const statType = statTypes.find((stat) => stat.name === key)?.id;

        if (statType === undefined) {
            console.error("Invalid statType");
            return;
        }

        fetch(`https://localhost:7073/api/Leaderboard?statType=${statType}&descending=${sortOrder}`)
            .then((response) => response.json())
            .then((data) => {
                setLeaderboard(data);
            })
            .catch((error) => console.error("Error fetching leaderboard:", error));
    };

    const handleSort = (key) => {
        if (sortKey === key) {
            setIsDescending(!isDescending); // Toggle sort direction if sorting by the same key
        } else {
            setSortKey(key); // Change sort key and reset to descending
            setIsDescending(true);
        }
    };

    const formatSkyblockExp = (exp) => {
        return (exp / 100).toFixed(2);
    };

    return (
        <Container className={`mt-4 transition ${isDarkMode ? "bg-dark text-light" : "bg-light text-dark"} w-100`}>
            <Table striped hover responsive className={`transition ${isDarkMode ? "table-dark" : "table-light"}`}>
                <thead className="w-100">
                    <tr>
                        <th>Name</th>
                        {statTypes.map((expType) => (
                            <LeaderboardTableHeader
                                key={expType.name}
                                expType={expType.name}
                                sortKey={sortKey}
                                isDescending={isDescending}
                                isDarkMode={isDarkMode}
                                handleSort={handleSort}
                            />
                        ))}
                    </tr>
                </thead>
                <tbody>
                    {leaderboard.map((player) => (
                        <tr key={player.mcUuid + player.profileName}>
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