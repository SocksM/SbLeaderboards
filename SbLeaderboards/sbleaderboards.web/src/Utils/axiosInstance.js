import axios from "axios";

// Create Axios instance with default configuration
const axiosInstance = axios.create({
    baseURL: import.meta.env.VITE_API_BASE_URL,
    timeout: 10000, // Set timeout to 10 seconds
    headers: {
        "Content-Type": "application/json",
    },
});

// Add a response interceptor for centralized error handling
axiosInstance.interceptors.response.use(
    (response) => response,
    (error) => {
        console.error("API Error:", error);
        // Optional: Display a user-friendly error message
        if (error.response) {
            alert(`Error: ${error.response.data.message || "Something went wrong!"}`);
        } else if (error.request) {
            alert("Error: No response received from server.");
        } else {
            alert("Error: Request setup failed.");
        }
        return Promise.reject(error);
    }
);

export default axiosInstance;