import { useParams } from "react-router-dom";
import { useState, useEffect } from "react";

function PlayerProfile() {
    const { playerId } = useParams(); // Get the playerId from the URL
    const [playerData, setPlayerData] = useState(null);

    useEffect(() => {
        // Fetch player data based on playerId
        fetch(`https://localhost:7073/api/Player/${playerId}`)
            .then((response) => response.json())
            .then((data) => setPlayerData(data))
            .catch((error) => console.error("Error fetching player data:", error));
    }, [playerId]);

    if (!playerData) return <div>Loading...</div>;

    return (
        <div>
            <h2>{playerData.name}</h2>
            {/* Render more player information here */}
        </div>
    );
}

export default PlayerProfile;
