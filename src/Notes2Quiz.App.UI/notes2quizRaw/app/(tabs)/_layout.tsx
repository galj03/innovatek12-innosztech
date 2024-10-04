import { Tabs } from 'expo-router';
import React from 'react';

import { TabBarIcon } from '@/components/navigation/TabBarIcon';
import { Colors } from '@/constants/Colors';
import { useColorScheme } from '@/hooks/useColorScheme';

export default function TabLayout() {

  return (
    <Tabs
      screenOptions={{
        headerShown: false,
      }}>
      <Tabs.Screen
        name="index"
        options={{
          title: 'Index',
          tabBarIcon: ({ focused }) => (
            <TabBarIcon name={focused ? 'home' : 'home-outline'} />
          ),
        }}
      />

      <Tabs.Screen
        name="masik"
        options={{
          title: 'Masik',
          tabBarIcon: ({ focused }) => (
            <TabBarIcon name={focused ? 'menu' : 'menu'} />
          ),
        }}
      />
    </Tabs>
  );
}
