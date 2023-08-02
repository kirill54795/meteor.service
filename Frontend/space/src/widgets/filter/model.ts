import { ref } from 'vue'
import { defineStore } from 'pinia'
import type { IFilterStore } from "./index.h";
import axios from "axios";


export const useFilterStore = defineStore('filter', (): IFilterStore => {

    return { }
})
