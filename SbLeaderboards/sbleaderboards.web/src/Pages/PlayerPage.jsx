import { useState, useEffect, useRef } from 'react';
import { useParams } from 'react-router-dom';
import { Table, Container, Spinner } from 'react-bootstrap';
import { Chart as ChartJS, registerables } from 'chart.js';
import { Line } from 'react-chartjs-2';
import { useNightMode } from '../Provider/NightModeContext';
import { useProfileTypes } from '../Provider/ProfileTypeContext';
import { useProfileCuteNames } from '../Provider/ProfileCuteNameContext';

ChartJS.register(...registerables);

function PlayerPage() {
    const { playerId } = useParams();
    const [player, setPlayer] = useState(null);
    const [selectedProfile, setSelectedProfile] = useState(null);
    const [profilesWithStats, setProfilesWithStats] = useState([]);
    const { isDarkMode } = useNightMode();
    const profileTypeLabels = useProfileTypes();
    const profileCuteNameLabels = useProfileCuteNames();
    const [isLoading, setIsLoading] = useState(true);
    const chartRef = useRef(null);

    useEffect(() => {
        fetchPlayerData();
    }, [playerId]);

    const fetchPlayerData = async () => {
        try {
            let response = await fetch(`https://localhost:7073/api/Player/Mc${playerId}?includeChilderen=true`);
            if (response.status === 404) {
                response = await fetch(`https://localhost:7073/api/Player/StartTracking/${playerId}`);
            }
            if (!response.ok) throw new Error('Network response was not ok');
            const data = await response.json();
            processPlayerData(data);
        } catch (error) {
            console.error('Error fetching player data:', error);
        } finally {
            setIsLoading(false);
        }
    };

    const processPlayerData = (data) => {
        const profilesWithLatestStats = data.profiles.map(profile => ({
            ...profile,
            latestStats: profile.stats.sort((a, b) => new Date(b.timestamp) - new Date(a.timestamp)),
        }));
        setPlayer(data);
        setProfilesWithStats(profilesWithLatestStats);
        const highestSkyblockProfile = profilesWithLatestStats.reduce((maxProfile, profile) => {
            const skyblockExp = profile.latestStats.length > 0 ? profile.latestStats[0].skyblockExp : 0;
            return skyblockExp > (maxProfile.latestStats[0]?.skyblockExp || 0) ? profile : maxProfile;
        }, profilesWithLatestStats[0]);
        setSelectedProfile(highestSkyblockProfile);
    };

    useEffect(() => {
        return () => {
            if (chartRef.current) {
                chartRef.current.destroy();
            }
        };
    }, [selectedProfile]);

    const getRelevantStatsForProfile = (profile) => {
        const relevantStatKeys = [
            'skyblockExp', 'tamingExp', 'miningExp', 'foragingExp', 'enchantingExp',
            'carpentryExp', 'farmingExp', 'combatExp', 'fishingExp', 'alchemyExp',
            'runecraftingExp', 'socialExp', 'catacombsExp', 'healerExp',
            'archerExp', 'tankExp', 'berserkerExp', 'mageExp'
        ];
        const latestStats = profile.latestStats || [];
        return relevantStatKeys.map(statKey => ({
            key: statKey,
            values: latestStats.map(stat => ({
                timestamp: new Date(stat.timestamp).toLocaleString(),
                value: stat[statKey] || 0 
            }))
        }));
    };

    const renderStatGraphs = (profile) => {
        const statsData = getRelevantStatsForProfile(profile);
        return statsData.map(stat => {
            const data = {
                labels: stat.values.map(value => value.timestamp),
                datasets: [{
                    label: stat.key,
                    data: stat.values.map(value => value.value),
                    borderColor: isDarkMode ? 'rgba(255, 255, 255, 0.5)' : 'rgba(0, 0, 0, 0.5)',
                    backgroundColor: isDarkMode ? 'rgba(255, 255, 255, 0.2)' : 'rgba(0, 0, 0, 0.2)',
                    fill: true,
                }]
            };

            return (
                <div key={stat.key} className="mb-4">
                    <h5>{stat.key.replace(/([A-Z])/g, ' $1')}</h5>
                    <Line ref={chartRef} data={data} options={{ responsive: true }} />
                </div>
            );
        });
    };

    return (
        <Container className={`transition mt-4 ${isDarkMode ? 'bg-dark text-light' : 'bg-light text-dark'}`}>
            {isLoading ? (
                <div className="text-center">
                    <Spinner animation="border" />
                    <p>Loading player data. Please wait, this might take a moment.</p>
                </div>
            ) : player ? (
                <>
                    <h2>{player.name}&#39;s Profiles</h2>
                    <div className="mb-3">
                        <label htmlFor="profileSelect" className="form-label">Select Profile:</label>
                        <select
                            id="profileSelect"
                            className={`form-select ${isDarkMode ? 'bg-dark text-light' : 'bg-light text-dark'}`}
                            value={selectedProfile?.id || ""}
                            onChange={(e) => {
                                const profile = profilesWithStats.find(p => p.id === parseInt(e.target.value));
                                setSelectedProfile(profile);
                            }}
                        >
                            {profilesWithStats.map((profile) => (
                                <option key={profile.id} value={profile.id}>
                                    {profileCuteNameLabels[profile.cuteName] || profile.cuteName} ({profileTypeLabels[profile.type] || profile.type})
                                </option>
                            ))}
                        </select>
                    </div>

                    {selectedProfile && (
                        <>
                            <h3>Stats for {profileCuteNameLabels[selectedProfile.cuteName] || selectedProfile.cuteName}</h3>
                            <Table striped bordered hover responsive className={`transition ${isDarkMode ? 'table-dark' : 'table-light'}`}>
                                <thead>
                                    <tr>
                                        <th>Stat Type</th>
                                        <th>Value</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {getRelevantStatsForProfile(selectedProfile).map((stat) => (
                                        <tr key={stat.key}>
                                            <td>{stat.key.replace(/([A-Z])/g, ' $1')}</td>
                                            <td>{stat.values.length > 0 ? stat.values[0].value : 'N/A'}</td>
                                        </tr>
                                    ))}
                                </tbody>
                            </Table>
                                {/* {renderStatGraphs(selectedProfile)} */}
                        </>
                    )}
                </>
            ) : (
                <p>Player not found.</p>
            )}
        </Container>
    );
}

export default PlayerPage;
