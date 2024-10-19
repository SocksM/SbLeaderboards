import { useState } from "react"; 
import { Form, Button } from "react-bootstrap"; 
import { useNightMode } from "../Provider/NightModeContext";
import { useNavigate } from "react-router-dom";

function Header() {
	const { isDarkMode, toggleDarkMode } = useNightMode();
	const [searchTerm, setSearchTerm] = useState("");
	const navigate = useNavigate(); 

	const handleSearch = async (e) => {
		e.preventDefault();
		if (searchTerm) {
			const isUUID = /^[0-9a-f]{32}$/i.test(searchTerm);
			let mcUuid = searchTerm;

			if (!isUUID) {
				try {
					const response = await fetch(`https://localhost:7073/api/MojangApiRerouter/Player/McUuid/${searchTerm}`);
					if (!response.ok) {
						throw new Error('Player not found');
					}
					const data = await response.json();
					mcUuid = data;
				} catch (error) {
					console.error('Error fetching player UUID:', error);
					alert(`Error: ${error.message}`);
					return;
				}
			}
			navigate(`/player/${mcUuid}`);
		}
	};


	return (
		<header className={`transition d-flex justify-content-between align-items-center p-3 ${isDarkMode ? "bg-dark text-light" : "bg-light text-dark"}`}>
			<h2>Hypixel Skyblock Leaderboards</h2>
			<Form inline onSubmit={handleSearch} className="d-flex">
				<Form.Control
					type="text"
					placeholder="Search by player name or UUID"
					value={searchTerm}
					onChange={(e) => setSearchTerm(e.target.value)} 
					className="me-2"
				/>
				<Button type="submit" variant={isDarkMode ? "dark" : "light"}>Search</Button>
			</Form>
			<Form.Check
				type="switch"
				id="dark-mode-switch"
				label="Night Mode"
				checked={isDarkMode}
				onChange={toggleDarkMode}
			/>
		</header>
	);
}

export default Header;
