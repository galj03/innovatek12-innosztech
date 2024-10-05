import { Tabs } from 'expo-router';
import React from 'react';

import { TabBarIcon } from '@/components/navigation/TabBarIcon';
import { Colors } from '@/constants/Colors';
import { useColorScheme } from '@/hooks/useColorScheme';
import { QuizProvider } from '@/hooks/QuizContext';

export default function TabLayout() {

  return (
    <QuizProvider>
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
          name="text"
          options={{
            title: 'Text',
            tabBarIcon: ({ focused }) => (
              <TabBarIcon name={focused ? 'menu' : 'menu'} />
            ),
          }}
        />

        <Tabs.Screen
          name="quiz"
          options={{
            title: 'Quiz',
            tabBarIcon: ({ focused }) => (
              <TabBarIcon name={focused ? 'search' : 'search'} />
            ),
          }}
        />
      </Tabs>
    </QuizProvider>
  );
}
