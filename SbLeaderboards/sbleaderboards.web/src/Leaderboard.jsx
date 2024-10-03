import { useState, useEffect } from "react";
import { Table, Button, Container } from "react-bootstrap";
import { useNightMode } from "./NightModeContext"; // Use the context



function Leaderboard() {
    const [leaderboard, setLeaderboard] = useState([]);
    const [sortKey, setSortKey] = useState(""); // Keeps track of which exp value to sort by
    const [isAscending, setIsAscending] = useState(true); // Track sorting order
    const { isDarkMode } = useNightMode(); // Access dark mode state from context

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

    const renderSortArrow = (key) => {
        if (sortKey === key || ((sortKey === "" || sortKey === null) && key === "skyblockExp")) {
            return isAscending ? "↑" : "↓";
        }
        return null; // No arrow if not the current sort column
    };

    const formatSkyblockExp = (exp) => {
        return (exp / 100).toFixed(2); // Divide by 100 and show 2 decimal points
    };

    return (
        <Container className={`mt-4 transition ${isDarkMode ? "bg-dark text-light" : "bg-light text-dark"} w-100`}>
            <Table striped hover responsive className={`transition ${isDarkMode ? "table-dark" : "table-light"} w-100`}>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>
                            <Button className="transition" variant={isDarkMode ? "dark" : "light"} onClick={() => handleSort("skyblockExp")}>
                                Skyblock Exp {renderSortArrow("skyblockExp")}
                            </Button>
                        </th>
                        <th>
                            <Button className="transition" variant={isDarkMode ? "dark" : "light"} onClick={() => handleSort("tamingExp")}>
                                Taming Exp {renderSortArrow("tamingExp")}
                            </Button>
                        </th>
                        <th>
                            <Button className="transition" variant={isDarkMode ? "dark" : "light"} onClick={() => handleSort("miningExp")}>
                                Mining Exp {renderSortArrow("miningExp")}
                            </Button>
                        </th>
                        <th>
                            <Button className="transition" variant={isDarkMode ? "dark" : "light"} onClick={() => handleSort("foragingExp")}>
                                Foraging Exp {renderSortArrow("foragingExp")}
                            </Button>
                        </th>
                        <th>
                            <Button className="transition" variant={isDarkMode ? "dark" : "light"} onClick={() => handleSort("enchantingExp")}>
                                Enchanting Exp {renderSortArrow("enchantingExp")}
                            </Button>
                        </th>
                        <th>
                            <Button className="transition" variant={isDarkMode ? "dark" : "light"} onClick={() => handleSort("carpentryExp")}>
                                Carpentry Exp {renderSortArrow("carpentryExp")}
                            </Button>
                        </th>
                        <th>
                            <Button className="transition" variant={isDarkMode ? "dark" : "light"} onClick={() => handleSort("farmingExp")}>
                                Farming Exp {renderSortArrow("farmingExp")}
                            </Button>
                        </th>
                        <th>
                            <Button className="transition" variant={isDarkMode ? "dark" : "light"} onClick={() => handleSort("combatExp")}>
                                Combat Exp {renderSortArrow("combatExp")}
                            </Button>
                        </th>
                        <th>
                            <Button className="transition" variant={isDarkMode ? "dark" : "light"} onClick={() => handleSort("fishingExp")}>
                                Fishing Exp {renderSortArrow("fishingExp")}
                            </Button>
                        </th>
                        <th>
                            <Button className="transition" variant={isDarkMode ? "dark" : "light"} onClick={() => handleSort("alchemyExp")}>
                                Alchemy Exp {renderSortArrow("alchemyExp")}
                            </Button>
                        </th>
                        <th>
                            <Button className="transition" variant={isDarkMode ? "dark" : "light"} onClick={() => handleSort("runecraftingExp")}>
                                Runecrafting Exp {renderSortArrow("runecraftingExp")}
                            </Button>
                        </th>
                        <th>
                            <Button className="transition" variant={isDarkMode ? "dark" : "light"} onClick={() => handleSort("socialExp")}>
                                Social Exp {renderSortArrow("socialExp")}
                            </Button>
                        </th>
                        <th>
                            <Button className="transition" variant={isDarkMode ? "dark" : "light"} onClick={() => handleSort("catacombsExp")}>
                                Catacombs Exp {renderSortArrow("catacombsExp")}
                            </Button>
                        </th>
                        <th>
                            <Button className="transition" variant={isDarkMode ? "dark" : "light"} onClick={() => handleSort("healerExp")}>
                                Healer Exp {renderSortArrow("healerExp")}
                            </Button>
                        </th>
                        <th>
                            <Button className="transition" variant={isDarkMode ? "dark" : "light"} onClick={() => handleSort("archerExp")}>
                                Archer Exp {renderSortArrow("archerExp")}
                            </Button>
                        </th>
                        <th>
                            <Button className="transition" variant={isDarkMode ? "dark" : "light"} onClick={() => handleSort("tankExp")}>
                                Tank Exp {renderSortArrow("tankExp")}
                            </Button>
                        </th>
                        <th>
                            <Button className="transition" variant={isDarkMode ? "dark" : "light"} onClick={() => handleSort("berserkerExp")}>
                                Berserker Exp {renderSortArrow("berserkerExp")}
                            </Button>
                        </th>
                        <th>
                            <Button className="transition" variant={isDarkMode ? "dark" : "light"} onClick={() => handleSort("mageExp")}>
                                Mage Exp {renderSortArrow("mageExp")}
                            </Button>
                        </th>
                    </tr>
                </thead>
                <tbody>
                    {leaderboard.map((player) => (
                        <tr key={player.profileId}>
                            <td>{player.name}</td>
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