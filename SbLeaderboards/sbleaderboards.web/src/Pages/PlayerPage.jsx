import { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import { Table, Container, Spinner } from 'react-bootstrap';
import { useNightMode } from '../Provider/NightModeContext';
import { useProfileTypes } from '../Provider/ProfileTypeContext';
import { useProfileCuteNames } from '../Provider/ProfileCuteNameContext';
import {
    LineChart, Line, XAxis, YAxis, CartesianGrid, Tooltip, Legend, ResponsiveContainer
} from 'recharts';
import axiosInstance from '../Compoments/axiosInstance';

function PlayerPage() {
    const { playerId } = useParams();
    const [player, setPlayer] = useState(null);
    const [selectedProfile, setSelectedProfile] = useState(null);
    const [profilesWithStats, setProfilesWithStats] = useState([]);
    const { isDarkMode } = useNightMode();
    const profileTypeLabels = useProfileTypes();
    const profileCuteNameLabels = useProfileCuteNames();
    const [isLoading, setIsLoading] = useState(true);

    useEffect(() => {
        fetchPlayerData();
    }, [playerId]);

    const fetchPlayerData = async () => {
        setIsLoading(true);
        try {
            let response;
            try {
                response = await axiosInstance.get(`/Player/Mc${playerId}?includeChilderen=true`);
            } catch (error) {
                if (error.response && error.response.status === 404) {
                    console.log("Player not found, starting tracking...");
                    response = await axiosInstance.get(`/Player/StartTracking/${playerId}`);
                } else {
                    throw error; // Re-throw if it's not a 404
                }
            }
            console.log("Successfully fetched player data");
            processPlayerData(response.data);
        } catch (error) {
            console.error('Error fetching player data:', error);
        } finally {
            setIsLoading(false);
        }
    };

    const processPlayerData = (data) => {
        const profilesWithLatestStats = data.profiles.map(profile => ({
            ...profile,
            latestStats: [...profile.stats].sort((a, b) => new Date(b.timestamp) - new Date(a.timestamp)),
        }));
        setPlayer(data);
        setProfilesWithStats(profilesWithLatestStats);

        let highestProfile = null;
        let highestExp = 0;
        for (const profile of profilesWithLatestStats) {
            const skyblockExp = profile.latestStats[0]?.skyblockExp || 0;
            if (skyblockExp > highestExp) {
                highestProfile = profile;
                highestExp = skyblockExp;
            }
        }
        setSelectedProfile(highestProfile);
    };

    const getRelevantStatsForProfile = (profile) => {
        const relevantStatKeys = [
            'skyblockExp', 'tamingExp', 'miningExp', 'foragingExp', 'enchantingExp',
            'carpentryExp', 'farmingExp', 'combatExp', 'fishingExp', 'alchemyExp',
            'runecraftingExp', 'socialExp', 'catacombsExp', 'healerExp',
            'archerExp', 'tankExp', 'berserkerExp', 'mageExp'
        ];
        const latestStats = profile?.latestStats || [];
        return relevantStatKeys.map((statKey) => ({
            key: statKey,
            value: latestStats[0]?.[statKey] || 'N/A',
        }));
    };

    const getChartDataForProfile = (profile) => {
        return profile?.latestStats?.map(stat => ({
            timestamp: new Date(stat.timestamp).toLocaleDateString(),
            ...stat
        })) || [];
    };

    const generateColor = (index) => {
        const hue = (index * 137.5) % 360; // Use the golden angle to evenly distribute colors
        return `hsl(${hue}, 70%, 50%)`; // HSL format: hue, saturation, lightness
    };

    const renderLinesForProfile = () => {
        const relevantStatKeys = [
            'skyblockExp', 'tamingExp', 'miningExp', 'foragingExp', 'enchantingExp',
            'carpentryExp', 'farmingExp', 'combatExp', 'fishingExp', 'alchemyExp',
            'runecraftingExp', 'socialExp', 'catacombsExp', 'healerExp',
            'archerExp', 'tankExp', 'berserkerExp', 'mageExp'
        ];

        return relevantStatKeys.map((key, index) => (
            <Line
                key={key}
                type="monotone"
                dataKey={key}
                stroke={generateColor(index)}
                dot={false} // Optional: removes dots on the line for cleaner look
            />
        ));
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
                                const profile = profilesWithStats.find(p => p.id === e.target.value);
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
                            <h3>Graph for {profileCuteNameLabels[selectedProfile.cuteName] || selectedProfile.cuteName}</h3>
                                <ResponsiveContainer width="100%" height={400}>
                                    <LineChart data={getChartDataForProfile(selectedProfile)}>
                                        <CartesianGrid strokeDasharray="3 3" />
                                        <XAxis dataKey="timestamp" />
                                        <YAxis />
                                        <Tooltip />
                                        <Legend />
                                        {renderLinesForProfile(selectedProfile)}
                                    </LineChart>
                                </ResponsiveContainer>
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
                                            <td>{stat.value}</td>
                                        </tr>
                                    ))}
                                </tbody>
                            </Table>
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