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
          name="camera"
          options={{
            title: 'Camera',
            tabBarIcon: ({ focused }) => (
              <TabBarIcon name={focused ? 'camera' : 'camera-outline'} />
            ),
          }}
        />

        <Tabs.Screen
          name="index"
          options={{
            title: 'Text',
            tabBarIcon: ({ focused }) => (
              <TabBarIcon name={focused ? 'menu' : 'menu-outline'} />
            ),
          }}
        />

        <Tabs.Screen
          name="quiz"
          options={{
            title: 'Quiz',
            tabBarIcon: ({ focused }) => (
              <TabBarIcon name={focused ? 'search' : 'search-outline'} />
            ),
          }}
        />

        <Tabs.Screen
          name="form"
          options={{
            title: 'PDF',
            tabBarIcon: ({ focused }) => (
              <TabBarIcon name={focused ? 'document-text-sharp' : 'document-text-outline'} />
            ),
          }}
        />
      </Tabs>
    </QuizProvider>
  );
}
