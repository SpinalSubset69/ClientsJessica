import axios from 'axios';

export const axios_instance = axios.create({
    baseURL: 'https://localhost:7176/api/',
    headers: {
        'Access-Control-Allow-Origin': '*',
        'Access-Control-Allow-Methods': 'GET,POST,OPTIONS,PUT,DELETE',
        'Access-Control-Allow-Headers': '*',
    },
})