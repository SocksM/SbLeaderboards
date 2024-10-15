import { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import { Table, Container } from 'react-bootstrap';

function PlayerPage() {
    const { playerId } = useParams(); // Get the playerId from the URL
    const [player, setPlayer] = useState(null);
    const [selectedProfile, setSelectedProfile] = useState(null);
    const [stats, setStats] = useState([]);

    useEffect(() => {
        // Fetch the player data by mcUuid
        fetch(`https://localhost:7073/api/Player/Mc${playerId}?includeChilderen=true`)
            .then(response => response.json())
            .then(data => {
                setPlayer(data);
                setSelectedProfile(data.profiles?.[0] || null); // Select the first profile by default
            })
            .catch(error => console.error('Error fetching player data:', error));
    }, [playerId]);

    useEffect(() => {
        if (selectedProfile) {
            // Fetch the stats for the selected profile
            fetch(`https://localhost:7073/api/Stats/${selectedProfile.id}`)
                .then(response => response.json())
                .then(data => setStats(data))
                .catch(error => console.error('Error fetching stats:', error));
        }
    }, [selectedProfile]);

    return (
        <Container>
            {player && (
                <>
                    <h2>{player.name}'s Profiles</h2>
                    <ul>
                        {player.profiles?.map((profile) => (
                            <li key={profile.id} onClick={() => setSelectedProfile(profile)}>
                                {profile.cuteName} ({profile.type})
                            </li>
                        ))}
                    </ul>

                    {selectedProfile && (
                        <>
                            <h3>Stats for {selectedProfile.cuteName}</h3>
                            <Table striped bordered hover>
                                <thead>
                                    <tr>
                                        <th>Stat Type</th>
                                        <th>Value</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr><td>Skyblock Exp</td><td>{stats.skyblockExp}</td></tr>
                                    <tr><td>Taming Exp</td><td>{stats.tamingExp}</td></tr>
                                    <tr><td>Mining Exp</td><td>{stats.miningExp}</td></tr>
                                    {/* ... other stats */}
                                </tbody>
                            </Table>
                        </>
                    )}
                </>
            )}
        </Container>
    );
}

export default PlayerPage;