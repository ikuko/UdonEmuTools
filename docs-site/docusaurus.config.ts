import {themes as prismThemes} from 'prism-react-renderer';
import type {Config} from '@docusaurus/types';
import type * as Preset from '@docusaurus/preset-classic';

const config: Config = {
  title: 'UdonEmu',
  tagline: 'UdonAssembly エミュレーター',
  favicon: 'img/favicon.ico',

  // GitHub Pages (Project site)
  url: 'https://ikuko.github.io',
  baseUrl: '/UdonEmuTools/',
  trailingSlash: true,

  organizationName: 'ikuko',
  projectName: 'UdonEmuTools',

  onBrokenLinks: 'throw',
  onBrokenMarkdownLinks: 'warn',

  i18n: {
    defaultLocale: 'ja',
    locales: ['ja'],
  },

  presets: [
    [
      'classic',
      {
        docs: {
          routeBasePath: '/', // ルート直下にDocsを出す
          sidebarPath: './sidebars.ts',
          editUrl: 'https://github.com/ikuko/UdonEmuTools/tree/main/docs-site/',
        },
        blog: false,
        theme: {
          customCss: './src/css/custom.css',
        },
      } satisfies Preset.Options,
    ],
  ],

  themeConfig: {
    navbar: {
      title: 'UdonEmu',
      items: [
        {to: '/', label: 'ドキュメント', position: 'left'},
        {
          href: 'https://github.com/ikuko/UdonEmuTools',
          label: 'GitHub',
          position: 'right',
        },
      ],
    },
    footer: {
      style: 'dark',
      links: [
        {
          title: 'Docs',
          items: [
            {label: 'はじめに', to: '/intro'},
            {label: 'インストール', to: '/install'},
            {label: 'クイックスタート', to: '/quickstart'},
          ],
        },
        {
          title: 'Links',
          items: [{label: 'GitHub', href: 'https://github.com/ikuko/UdonEmuTools'}],
        },
      ],
      copyright: `Copyright © ${new Date().getFullYear()} ikuko`,
    },
    prism: {
      theme: prismThemes.github,
      darkTheme: prismThemes.dracula,
      additionalLanguages: ['csharp'],
    },
  } satisfies Preset.ThemeConfig,
};

export default config;
