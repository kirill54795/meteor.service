<script setup lang="ts">
import { FilterForm } from '@/filter'
import { columns } from "./index.h";
  //TODO: Mock data.
  const dataSource = [
    {
      key: '1',
      name: 'Mike',
      age: 32,
      address: '10 Downing Street',
    },
    {
      key: '2',
      name: 'John',
      age: 42,
      address: '10 Downing Street',
    },
  ];
</script>
<template>
  <main>
    <FilterForm />
    <a-table :dataSource="dataSource" :columns="columns" />
  </main>
</template>

<style scoped>
  main {
    width: calc(100vw - 16px);
    height: calc(100vh - 16px);
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    gap: 10px;
  }
  .ant-table-wrapper {
    width: 100%;
  }
</style>