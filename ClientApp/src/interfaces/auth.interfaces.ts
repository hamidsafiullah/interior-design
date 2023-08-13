
export interface RegisterData {
    firstName: string;
    lastName: string;
    email: string;
    password: string;
    isDeleted: boolean;
    deletedAt: Date;
}

export interface LoginData {
    email: string;
    password: string;
}
