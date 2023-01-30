import { axios_instance } from "../axios";

export class Bills {
    async CreateBillAsync(bill) {
        try {
            await axios_instance.post("bills", bill);
        } catch (error) {
            throw error;
        }
    }


    async GetPersonalDataByRFCAsync(rfc = "") {
        try {
            return await axios_instance.get(`bills?RFC=${rfc}`);
        } catch (error) {
            throw error;
        }
    }

    async GetAllBillsAsync() {
        try {
            return await axios_instance.get("bills/all");
        } catch (error) {
            throw error;
        }
    }

    async ValidateAccesAsync(password) {
        try {
            return await axios_instance.post("bills/validateaccess?password=" + password);
        } catch (error) {
            throw error;
        }
    }
}