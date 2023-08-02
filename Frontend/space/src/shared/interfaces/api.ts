export interface IApiStore<T> {
    data: T[]
    loading: boolean
    error: string
}