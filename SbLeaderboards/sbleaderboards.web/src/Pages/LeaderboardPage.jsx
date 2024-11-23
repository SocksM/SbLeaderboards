import { useState, useEffect } from "react";
import { Table, Container, Button, Spinner } from "react-bootstrap";
import { useNightMode } from "../Provider/NightModeContext";
import LeaderboardTableHeader from "../Compoments/LeaderboardTableHeader";
import { Link } from "react-router-dom";
import axiosInstance from "../Utils/axiosInstance";

function Leaderboard() {
	const [leaderboard, setLeaderboard] = useState([]);
	const [sortKey, setSortKey] = useState("skyblockExp");
	const [isDescending, setIsDescending] = useState(true);
	const [page, setPage] = useState(0);
	const [totalPages, setTotalPages] = useState(1);
	const { isDarkMode } = useNightMode();
	const [isLoading, setIsLoading] = useState(true); // Loading state

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
		{ name: "mageExp", id: 17 },
	];

	useEffect(() => {
		fetchLeaderboard(sortKey, isDescending, page);
	}, [sortKey, isDescending, page]);

	const fetchLeaderboard = async (key, descending, page) => {
		setIsLoading(true); // Start loading
		const sortOrder = descending ? "true" : "false";
		const statType = statTypes.find((stat) => stat.name === key)?.id;

		if (statType === undefined) {
			console.error("Invalid statType");
			return;
		}

		try {
			const { data } = await axiosInstance.get(
				`/Leaderboard?statType=${statType}&descending=${sortOrder}&page=${page}`
			);
			setLeaderboard(data.leaderboard);
			setTotalPages(data.totalPages);
		} catch (error) {
			console.error("Error fetching leaderboard:", error);
		} finally {
			setIsLoading(false); // End loading
		}
	};

	const handleSort = (key) => {
		if (sortKey === key) {
			setIsDescending(!isDescending);
		} else {
			setSortKey(key);
			setIsDescending(true);
		}
	};

	const handleNextPage = () => {
		if (page < totalPages - 1) {
			setPage(page + 1);
		}
	};

	const handlePreviousPage = () => {
		if (page > 0) {
			setPage(page - 1);
		}
	};

	const formatSkyblockExp = (exp) => {
		return (exp / 100).toFixed(2);
	};

	return (
		<Container className={`mt-4 transition ${isDarkMode ? "bg-dark text-light" : "bg-light text-dark"} w-100`}>
			{isLoading ? (
				<div className="text-center">
					<Spinner animation="border" />
					<p>Loading leaderboard data. Please wait...</p>
				</div>
			) : (
				<>
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
									<td>{player.stats.tamingExp.toLocaleString()}</td>
									<td>{player.stats.miningExp.toLocaleString()}</td>
									<td>{player.stats.foragingExp.toLocaleString()}</td>
									<td>{player.stats.enchantingExp.toLocaleString()}</td>
									<td>{player.stats.carpentryExp.toLocaleString()}</td>
									<td>{player.stats.farmingExp.toLocaleString()}</td>
									<td>{player.stats.combatExp.toLocaleString()}</td>
									<td>{player.stats.fishingExp.toLocaleString()}</td>
									<td>{player.stats.alchemyExp.toLocaleString()}</td>
									<td>{player.stats.runecraftingExp.toLocaleString()}</td>
									<td>{player.stats.socialExp.toLocaleString()}</td>
									<td>{player.stats.catacombsExp.toLocaleString()}</td>
									<td>{player.stats.healerExp.toLocaleString()}</td>
									<td>{player.stats.archerExp.toLocaleString()}</td>
									<td>{player.stats.tankExp.toLocaleString()}</td>
									<td>{player.stats.berserkerExp.toLocaleString()}</td>
									<td>{player.stats.mageExp.toLocaleString()}</td>
								</tr>
							))}
						</tbody>
					</Table>
					<div className="d-flex justify-content-between mt-3">
						<Button variant="primary" onClick={handlePreviousPage} disabled={page === 0}>
							Previous
						</Button>
						<span>Page {page + 1} of {totalPages}</span>
						<Button variant="primary" onClick={handleNextPage} disabled={page === totalPages - 1}>
							Next
						</Button>
					</div>
				</>
			)}
		</Container>
	);
}

export default Leaderboard;