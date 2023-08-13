export class UserModel {
    id: number;
    email: string;
    password: string;
    firstName: string;
    lastName: string;
    isDeleted: boolean;
    deletedAt: Date | null;

    constructor() {
        this.id = 0;
        this.email = "";
        this.password = "";
        this.firstName = "login";
        this.lastName = "";
        this.isDeleted = false;
        this.deletedAt = null;
    }
}