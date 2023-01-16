import { axios_instance } from "../axios";

export class Bills {
    async CreateBillAsync(bill) {
        try {
            await axios_instance.post("bills", bill);
        } catch (error) {
            throw error;
        }
    }


    async GetBillsAsync() {
        try {
            return await axios_instance.get("bills")
        } catch (error) {
            throw error;
        }
    }
}