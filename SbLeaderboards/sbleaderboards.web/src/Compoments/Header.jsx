import { useState } from "react"; 
import { Form, Button } from "react-bootstrap"; 
import { useNightMode } from "../Provider/NightModeContext";
import { useNavigate } from "react-router-dom";
import { Link } from "react-router-dom";
import '../styles.css'
import axiosInstance from "./axiosInstance";

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
					const { data } = await axiosInstance.get(`/MojangApiRerouter/Player/McUuid/${searchTerm}`);
					mcUuid = data;
				} catch (error) {
					console.error("Error fetching player UUID:", error);
					return;
				}
			}
			navigate(`/player/${mcUuid}`);
		}
	};


	return (
		<header className={`transition d-flex justify-content-between align-items-center p-3 ${isDarkMode ? "bg-dark text-light" : "bg-light text-dark"}`}>

			<Link to={`/`} className="link-text">
				<h2>Hypixel Skyblock Leaderboards</h2>
			</Link>
			
			<Form inline onSubmit={handleSearch} className="d-flex">
				<Form.Control
					type="text"
					placeholder="Search"
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
